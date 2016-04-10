using System;
using NUnit.Framework;
using NSubstitute;
using Gilgamesh.Entities.StaticData.Currency;
using System.Collections.Generic;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.Portfolio;
using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.Entities.Tests
{
    public class PortfolioTests
    {
        [Test]
        public void ShouldLoadProperlyPortfolios()
        {
            //Arrange

            var instrument = new Share
            {
                CurrencyId = 3,
                InstrumentId = 29,
                MarketId = 109,
                Name = "VANGUARD S&P 500 ETF",
                Reference = new Reference { Name = "VOO", ReferecenceTypeId = 1 },
                MetaModel = new ShareStandardMetaModel()
            };

            var trade1 = new Trade(instrument)
            {
                Fees = 10,
                Instrument = instrument,
                PortfolioId = 2,
                Price = 100,
                Quantity = 100,
                Status = Status.Live,
                TradeDate = new DateTime(2016, 1, 4),
                TradeId = 1
            };

            var trade2 = new Trade(instrument)
            {
                Fees = 10,
                Instrument = instrument,
                PortfolioId = 2,
                Price = 120,
                Quantity = -90,
                Status = Status.Live,
                TradeDate = new DateTime(2016, 4, 4),
                TradeId = 1
            };

            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            ITradeRepository trades = Substitute.For<ITradeRepository>();
            IRepository<CommonNonWorkingDay> nonWorkingDays = Substitute.For<IRepository<CommonNonWorkingDay>>();
            nonWorkingDays.GetAll().Returns(new List<CommonNonWorkingDay>());

            IRepository<Instrument> instruments = Substitute.For<IRepository<Instrument>>();
            instruments.Get(29).Returns(instrument);

            trades.GetInstrumentsInPortfolio(2).Returns(new List<int> { 29 });
            trades.GetInstrumentsInPortfolio(1).Returns(new List<int>());
            trades.GetLiveTradeForFolioAndInstrumentAtDate(2, 29, date).Returns(new List<Trade> { trade1, trade2 });

            IUnitOfWork unitOfWork = Substitute.For<IUnitOfWork>();
            unitOfWork.Trades.Returns(trades);
            unitOfWork.Instruments.Returns(instruments);
            unitOfWork.CommonNonWorkingDayRepository.Returns(nonWorkingDays);



            UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;


            Currency chf = new Currency {Id=3,CurrencyName = "CHF"};
            var compteTitresSaxobank = new Portfolio.Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio.Portfolio>(), IsStrategy = true, Name = "Compte Titres Saxobank",PortfolioId = 2};
            var saxoBank = new Portfolio.Portfolio() { PortfolioCurrency = chf, ChildPortfolios = new List<Portfolio.Portfolio>(), IsStrategy = false, Name = "Saxobank", PortfolioId = 1};
            saxoBank.ChildPortfolios.Add(compteTitresSaxobank);
            IMarketData marketData = Substitute.For<IMarketData>();
            marketData.GetSpot(instrument.InstrumentId).Returns(120);




            //Act
            saxoBank.Load();

            //Assert
            Assert.AreEqual(0, saxoBank.GetPositionsCount());
            Assert.AreEqual(1, saxoBank.ChildPortfolios[0].GetPositionsCount());
            Assert.AreEqual(10, saxoBank.ChildPortfolios[0].GetNthPosition(0).SecuritiesNumber);
            Assert.AreEqual(1980, saxoBank.ChildPortfolios[0].GetNthPosition(0).GetResult(marketData));

        }

    }
}
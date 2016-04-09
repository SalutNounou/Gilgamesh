
using System.Collections.Generic;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.Portfolio;
using NUnit.Framework;
using Gilgamesh.Entities;
using NSubstitute;

namespace Gilgamesh.Entities.Tests

{
    public class PositionTests
    {
        [Test]
        public void ShouldEvaluateCorrectlyLongPositionPnL()
        {
            //Arrange
            Instrument instrument = new Share {CurrencyId = 1, InstrumentId = 29,MetaModel = new ShareStandardMetaModel()};
            Trade trade = new Trade(instrument) {Fees = 10,Quantity = 100,Price = 10, PortfolioId = 1};
            IMarketData marketData = Substitute.For<IMarketData>();
            marketData.GetSpot(instrument.InstrumentId).Returns(20);

            Position position = new Position {Instrument = instrument,PortfolioId = 1,PositionId = 1,SecuritiesNumber = 100, Trades = new List<Trade> { trade } };
            

            //act
            var result = position.GetResult(marketData);

            //Assert
            Assert.AreEqual(990,result);
        }

        [Test]
        public void ShouldEvaluateCorrectlyShortPositionPnL()
        {
            //Arrange
            Instrument instrument = new Share { CurrencyId = 1, InstrumentId = 29, MetaModel = new ShareStandardMetaModel() };
            Trade trade = new Trade(instrument) { Fees = 10, Quantity = -100, Price = 10, PortfolioId = 1 };
            IMarketData marketData = Substitute.For<IMarketData>();
            marketData.GetSpot(instrument.InstrumentId).Returns(5);

            Position position = new Position { Instrument = instrument, PortfolioId = 1, PositionId = 1, SecuritiesNumber = -100 , Trades = new List<Trade> {trade} };
           
            //act
            var result = position.GetResult(marketData);

            //Assert
            Assert.AreEqual(490, result);
        }
    }
}
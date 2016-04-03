using System;
using System.Collections.Generic;
using System.Linq;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;
using NUnit.Framework;

namespace Gilgamesh.Entities.Tests
{
    class MarketDataRetrieverTests
    {

        [Test]
        public void ShouldRetrieveCorrectFixings()
        {
            //Arrange
            IMarketDataRetriever marketDataRetriever = new MarketDataRetriever();
            //Act
            var fixings = marketDataRetriever.GetHistoricalFixings("VOO", new DateTime(2016, 3, 21),
                new DateTime(2016, 3, 22));

            //Assert
            Assert.AreEqual(2, fixings.Count);
            Assert.IsNotNull(fixings.FirstOrDefault());
            Assert.AreEqual(187.630005, fixings.FirstOrDefault().Last);
        }


        [Test]
        public void ShouldRetrieveCorrectForex()
        {
            //Arrange
            IMarketDataRetriever marketDataRetriever = new MarketDataRetriever();
            //Act
            var last = marketDataRetriever.GetForexAtDate("USD", "CHF", new DateTime(2016, 3, 22));
            //Assert
            Assert.IsNotNull(last);
            Assert.AreEqual(last.Reference, "USD/CHF");
            Assert.AreEqual(last.Last, 1.0299);
        }

        [Test]
        public void ShouldRetrievedCorrectHistoricalForexs()
        {
            //Arrange
            IMarketDataRetriever marketDataRetriever = new MarketDataRetriever();
            Currency currencyFrom = new Currency(new List<BankHoliday> { new BankHoliday { Day = new DateTime(2016, 5, 1) } }, new List<CommonNonWorkingDay> { new CommonNonWorkingDay { Day = new DateTime(2016, 1, 1) } }) { CurrencyName = "USD" };
            Currency currencyTo = new Currency(new List<BankHoliday> { new BankHoliday { Day = new DateTime(2016, 5, 1) } }, new List<CommonNonWorkingDay> { new CommonNonWorkingDay { Day = new DateTime(2016, 1, 1) } }) { CurrencyName = "CHF" };
            //Act
            var last = marketDataRetriever.GetForexHistoricalFixings(currencyFrom, currencyTo, new DateTime(2016, 3, 21), new DateTime(2016, 03, 22));
            //Assert
            Assert.IsNotNull(last);
            Assert.IsNotNull(last.FirstOrDefault());
            Assert.IsNotNull(last.LastOrDefault());
            Assert.AreEqual(last.LastOrDefault().Reference, "USD/CHF");
            Assert.AreEqual(last.LastOrDefault().Last, 1.0325);
        }

    }
}

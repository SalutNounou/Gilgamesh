using System;
using System.Collections.Generic;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Business.Strategies;
using Gilgamesh.Entities.MarketData.MarketDataRetriever;
using NUnit.Framework;


namespace Gilgamesh.Business.Test
{
    public class MomentumStrategyTest
    {
        [Test]
        public void ShouldCalculateCorrectlyPerformance()
        {
            //Arrange
            List<Fixings> fxings = new List<Fixings> { new Fixings {Last=100}, new Fixings{Last=50} };
            MomentumStratgy strategy = new MomentumStratgy(new MarketDataRetriever());
            //Act
            var perf = strategy.CalculatePerformance(fxings);
            //Assert
            Assert.AreEqual(1,perf);
        }

        [TestCase(1,2,3,ActionsMomentumStrategy.BuyTreasuryBonds)]
        [TestCase(1, 3,2, ActionsMomentumStrategy.BuyMsciWorlMinusUs)]
        [TestCase(3, 2,1, ActionsMomentumStrategy.BuySandP500)]
        [TestCase(-3,- 2, -1, ActionsMomentumStrategy.StayLiquid)]
        public void ShouldDecideCorrectActionGivenAPerfSet(decimal perfSAndP, decimal perfWorld, decimal perfBills, ActionsMomentumStrategy expected)
        {
            //Arrange
            MomentumStratgy strategy = new MomentumStratgy(new MarketDataRetriever());
            //Act
            var actual = strategy.DecideWhatToBuy(perfSAndP, perfWorld, perfBills);
            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void AcceptanceTest()
        {
            //Arrange
            MomentumStratgy strategy = new MomentumStratgy(new MarketDataRetriever());
            //Act
            var actual = strategy.GetInvestmentAction(new DateTime(2016, 03, 23));
            //Assert
            Assert.AreEqual(ActionsMomentumStrategy.StayLiquid, actual);
        }
    }
}

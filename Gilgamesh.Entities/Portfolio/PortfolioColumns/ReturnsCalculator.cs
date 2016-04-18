using System;
using System.Collections.Generic;
using System.Linq;

namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class ReturnsCalculator
    {
        public static decimal ComputeReturnsForPosition(Position position)
        {
            DateTime startDate = position.Trades.Min(t => t.TradeDate);
            DateTime today = MarketData.MarketData.GetCurrentMarketData().GetDate();
            return ComputeReturnsForPositionBetweenDates(position, startDate, today);
        }


        public static decimal ComputeReturnsForPositionBetweenDates(Position position, DateTime startDate, DateTime endDate)
        {
            decimal returns=1;
            var dates = position.Trades.Where(t=>t.TradeDate<=endDate).GroupBy(t => t.TradeDate).Select(t => t.Key).ToList(); //.ToList();
            dates.Sort();
            if(dates.Count<1) return 1;
            int cashFlowIntervalCount = dates.Count - 1;
            for (int currentInterval = 0; currentInterval < cashFlowIntervalCount; currentInterval++)
            {
                var intervalStartDate = dates[currentInterval];
                var intervalEndDate = dates[currentInterval + 1];
                decimal intermediateReturns = GetIntermediateReturns(position, intervalStartDate, intervalEndDate);
                returns *= intermediateReturns;
            }
            var lastReturn = GetIntermediateReturns(position, dates[cashFlowIntervalCount], endDate);
            returns *= lastReturn;
            return returns;
        }

        private static decimal GetIntermediateReturns(Position position, DateTime intervalStartDate, DateTime intervalEndDate)
        {

            if (intervalStartDate == intervalEndDate) return 1;
            var initialTrades = position.Trades.Where(t => t.TradeDate == intervalStartDate);
            var trades = initialTrades as IList<Trade> ?? initialTrades.ToList();
            var initialQuantity = trades.Sum(t => t.Quantity);
            if (Math.Abs(initialQuantity) < (decimal) 0.000001) return 1;
            var initialAmount = trades.Sum(t => t.Quantity*t.Price);
            var fees = trades.Where(t => t.TradeDate == intervalStartDate).Sum(t => t.Fees);
            if (Math.Abs(initialAmount) < (decimal) 0.000000001) return 1;
            var finalPrice = MarketData.MarketData.GetCurrentMarketData()
                .GetPriceAtDate(position.Instrument.InstrumentId, intervalEndDate);
            var finalAmount = finalPrice*initialQuantity;
            var intermediateReturns = finalAmount/(initialAmount+fees);
            return intermediateReturns;
        }
    }
}
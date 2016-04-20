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


        public static decimal ComputeForexReturns(Position position, int targetCurrencyId)
        {
            DateTime startDate = position.Trades.Min(t => t.TradeDate);
            DateTime today = MarketData.MarketData.GetCurrentMarketData().GetDate();
            return ComputeForexReturnsForPositionBetweenDates(position, startDate, today, targetCurrencyId);
        }

        public static decimal ComputeForexReturnsForPositionBetweenDates(Position position, DateTime startDate,
            DateTime endDate, int targetCurrencyId)
        {
            decimal returns = 1;
            var dates = position.Trades.Where(t => t.TradeDate <= endDate).GroupBy(t => t.TradeDate).Select(t => t.Key).ToList(); //.ToList();
            dates.Sort();
            if (dates.Count < 1) return 1;
            int cashFlowIntervalCount = dates.Count - 1;
            for (int currentInterval = 0; currentInterval < cashFlowIntervalCount; currentInterval++)
            {
                var intervalStartDate = dates[currentInterval];
                var intervalEndDate = dates[currentInterval + 1];
                decimal intermediateReturns = GetIntermediateForexReturns(position, intervalStartDate, intervalEndDate, targetCurrencyId);
                returns *= intermediateReturns;
            }
            var lastReturn = GetIntermediateForexReturns(position, dates[cashFlowIntervalCount], endDate, targetCurrencyId);
            returns *= lastReturn;
            return returns;
        }


        public static decimal GetIntermediateForexReturns(Position position, DateTime intervalStartDate, DateTime intervalEndDate, int targetCurrencyId)
        {
            if (intervalStartDate == intervalEndDate) return 1;
            var initialForex =
                MarketData.MarketData.GetCurrentMarketData()
                    .GetForexAtDate(position.Instrument.CurrencyId, targetCurrencyId, intervalStartDate);
            var finalForex = MarketData.MarketData.GetCurrentMarketData()
                    .GetForexAtDate(position.Instrument.CurrencyId, targetCurrencyId, intervalEndDate);
            if (initialForex != 0)
                return finalForex/initialForex;
            return 1;
        }


        public static decimal ComputeReturnsForPositionBetweenDates(Position position, DateTime startDate, DateTime endDate)
        {
            decimal returns = 1;
            var dates = position.Trades.Where(t => t.TradeDate <= endDate).GroupBy(t => t.TradeDate).Select(t => t.Key).ToList(); //.ToList();
            dates.Sort();
            if (dates.Count < 1) return 1;
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

        private static decimal GetIntermediateReturns(Position position, DateTime intervalStartDate, DateTime intervalEndDate, bool withFees=true)
        {

            if (intervalStartDate == intervalEndDate) return 1;

            var initialQuantity = GetInitialQuantityAtStartDate(position, intervalStartDate);
            var quantityFromBefore = QuantityFromBeforeStartDate(position, intervalStartDate);
            
            if (Math.Abs(initialQuantity+quantityFromBefore) < (decimal)0.000001) return 1;
            
            var initialAmount = GetinitialAmountForPosition(position, intervalStartDate, intervalEndDate);
            if (Math.Abs(initialAmount) < (decimal)0.000000001) return 1;

            var fees = GetFeesAtStartDate(position, intervalStartDate);

            var finalPrice = MarketData.MarketData.GetCurrentMarketData()
                .GetPriceAtDate(position.Instrument.InstrumentId, intervalEndDate)*(position.Instrument.QuotationInCents?1/100:1);

            var finalAmount = finalPrice * (initialQuantity+quantityFromBefore);

            var intermediateReturns = finalAmount / (initialAmount + (withFees?fees:0));
            return intermediateReturns;
        }

        private static decimal QuantityFromBeforeStartDate(Position position, DateTime intervalStartDate)
        {
            var tradesFromBefore = position.Trades.Where(t => t.TradeDate < intervalStartDate);
            var tradesFromBeforeLsist = tradesFromBefore as IList<Trade> ?? tradesFromBefore.ToList();
            var quantityFromBefore = tradesFromBeforeLsist.Sum(t => t.Quantity);
            return quantityFromBefore;
        }

        private static decimal GetInitialQuantityAtStartDate(Position position, DateTime intervalStartDate)
        {
            var initialTrades = position.Trades.Where(t => t.TradeDate == intervalStartDate);
            var initialTradesList = initialTrades as IList<Trade> ?? initialTrades.ToList();
            var initialQuantity = initialTradesList.Sum(t => t.Quantity);
            return initialQuantity;
        }

        public static decimal GetFeesAtStartDate(Position pos, DateTime intervalStartDate)
        {
            var initialTrades = pos.Trades.Where(t => t.TradeDate == intervalStartDate);
            return initialTrades.Sum(t => t.Fees);
        }


        public static decimal CalculateReturnsForFolio(int portfolioCode)
        {
            var portfolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(portfolioCode);
            if (!portfolio.IsStrategy) return 0;
            portfolio.Load();
            var startDate = GetFolioStartDate( portfolio);
            DateTime today = MarketData.MarketData.GetCurrentMarketData().GetDate();
            return ComputeReturnsForFolioBetweenDates(portfolio, startDate, today);
        }

        public static decimal ComputeReturnsForFolioBetweenDates(Portfolio portfolio, DateTime startDate,
            DateTime endDate)
        {
            int posCount = portfolio.GetPositionsCount();
            var dates = new List<DateTime>();
            for (int currentPos = 0; currentPos < posCount; currentPos++)
            {
                var pos = portfolio.GetNthPosition(currentPos);
                dates.AddRange(pos.Trades.Where(t=>t.TradeDate<endDate).GroupBy(t => t.TradeDate).Select(t => t.Key).ToList());
            }
            dates.Sort();
            decimal sumAmounts = 0;
            decimal sumFinalAmounts = 0;
            decimal totalReturns = 1;
            int cashFlowIntervalCount = dates.Count - 1;
            
            for (int currentInterval = 0; currentInterval < cashFlowIntervalCount; currentInterval++)
            {
                var intervalStartDate = dates[currentInterval];
                var intervalEndDate = dates[currentInterval + 1];
                if (intervalStartDate == intervalEndDate) continue;
                sumAmounts = 0;
                sumFinalAmounts = 0;
                for (int currentPos = 0; currentPos < posCount; currentPos++)
                {
                    var pos = portfolio.GetNthPosition(currentPos);
                    SumAmountsForPosition(portfolio, pos, intervalStartDate, intervalEndDate, ref sumAmounts, ref sumFinalAmounts);
                }
                totalReturns = (sumAmounts == 0) ? totalReturns : totalReturns*sumFinalAmounts/sumAmounts;
            }
            sumAmounts = 0;
            sumFinalAmounts = 0;

            for (int currentPos = 0; currentPos < posCount; currentPos++)
            {
                var pos = portfolio.GetNthPosition(currentPos);
                SumAmountsForPosition(portfolio, pos, dates[cashFlowIntervalCount], endDate, ref sumAmounts, ref sumFinalAmounts);
            }
            totalReturns = (sumAmounts == 0) ? totalReturns : totalReturns * sumFinalAmounts / sumAmounts;
            return totalReturns;
        }

        private static void SumAmountsForPosition(Portfolio portfolio, Position pos, DateTime intervalStartDate,
            DateTime intervalEndDate,ref decimal sumAmounts, ref decimal sumFinalAmounts)
        {
            var initialAmount = GetinitialAmountForPosition(pos, intervalStartDate, intervalEndDate);
            var initialFx = MarketData.MarketData.GetCurrentMarketData()
                .GetForexAtDate(pos.GetCurrencyCode(), portfolio.PortfolioCurrency.Id, intervalStartDate);
            var fees = GetPositionFees(pos, intervalStartDate);
            var perfPos = GetIntermediateReturns(pos, intervalStartDate, intervalEndDate, false);
            var finalFx = MarketData.MarketData.GetCurrentMarketData()
                .GetForexAtDate(pos.GetCurrencyCode(), portfolio.PortfolioCurrency.Id, intervalEndDate);

            sumAmounts += (initialAmount + fees)*initialFx;
            sumFinalAmounts += initialAmount*perfPos*finalFx;
        }

        private static decimal GetPositionFees(Position position, DateTime date)
        {
            return position.Trades.Where(t => t.TradeDate==date ).Sum(t => t.Fees);
        }

        private static decimal GetinitialAmountForPosition(Position position, DateTime periodStartDate, DateTime periodEndDate)
        {

            var initialTrades = position.Trades.Where(t => t.TradeDate == periodStartDate);
            var initialTradesList = initialTrades as IList<Trade> ?? initialTrades.ToList();
            var initialQuantity = initialTradesList.Sum(t => t.Quantity);

            var tradesFromBefore = position.Trades.Where(t => t.TradeDate < periodStartDate);
            var tradesFromBeforeLsist = tradesFromBefore as IList<Trade> ?? tradesFromBefore.ToList();
            var quantityFromBefore = tradesFromBeforeLsist.Sum(t => t.Quantity);

            if (Math.Abs(initialQuantity + quantityFromBefore) < (decimal)0.000001) return 0;

            var officialPriceStartDate = MarketData.MarketData.GetCurrentMarketData()
                .GetPriceAtDate(position.Instrument.InstrumentId, periodStartDate) * (position.Instrument.QuotationInCents ? 1 / 100 : 1);

            var amountStart = initialTradesList.Sum(t => t.Quantity * t.Price);
            var amountFromBefore = quantityFromBefore * officialPriceStartDate;

            var initialAmount = amountStart + amountFromBefore;


            return initialAmount;
        }

        private static DateTime GetFolioStartDate( Portfolio portfolio)
        {
            
            DateTime startDate = MarketData.MarketData.GetCurrentMarketData().GetDate();
            int posCount = portfolio.GetPositionsCount();
            for (int currentPos = 0; currentPos < posCount; currentPos++)
            {
                var pos = portfolio.GetNthPosition(currentPos);
                var dates = pos.Trades.GroupBy(t => t.TradeDate).Select(t => t.Key).ToList();
                dates.Sort();
                if (dates.Count <= 0) continue;
                startDate = startDate > dates[0] ? dates[0] : startDate;
            }
            return startDate;
        }
    }
}
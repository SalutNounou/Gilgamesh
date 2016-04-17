namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class PortfolioColumnUtils
    {
        public static double AggregateResultsForFolio(PortfolioColumn column, int portfolioCode, bool useForexConversion)
        {
            double valueToReturn = 0;
            var portfolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(portfolioCode);
            int posCount = portfolio.GetPositionsCount();
            for (int posIndex = 0; posIndex < posCount; posIndex++)
            {
                var position = portfolio.GetNthPosition(posIndex);
                if (position == null) continue;
                decimal fx = useForexConversion?MarketData.MarketData.GetCurrentMarketData().GetForex(position.GetCurrencyCode(),portfolio.PortfolioCurrency.Id):1;
                var style = new CellStyle();
                var value = new CellValue();

                column.GetPositionCell(position, style, value);
                switch (style.CellType)
                {
                    case ValueType.Decimal:
                        valueToReturn += (double)value.DecimalValue*(double)fx;
                        break;
                    case ValueType.Double:
                        valueToReturn += value.DoubleValue * (double)fx;
                        break;
                    case ValueType.Integer:
                        valueToReturn += value.IntValue *(double)fx;
                        break;
                    default:
                        break;
                }
            }

            foreach (var childPortfolio in portfolio.ChildPortfolios)
            {
                var fx = useForexConversion ? MarketData.MarketData.GetCurrentMarketData().GetForex(childPortfolio.PortfolioCurrency.Id, portfolio.PortfolioCurrency.Id) : 1;
                valueToReturn += AggregateResultsForFolio(column, childPortfolio.PortfolioId, useForexConversion)*(double)fx;
            }

            return valueToReturn;
        }
    }
}
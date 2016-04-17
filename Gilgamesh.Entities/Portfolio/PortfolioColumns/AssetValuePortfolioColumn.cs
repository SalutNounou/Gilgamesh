using System.Runtime.InteropServices;

namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class AssetValuePortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour=NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = (decimal)PortfolioColumnUtils.AggregateResultsForFolio(this, portfolioCode, true);
        }

        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = position.GetAssetValue(MarketData.MarketData.GetCurrentMarketData());
        }
    }


    public class PnlPortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;

            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(portfolioCode);

            if (!folio.IsStrategy)
            cellValue.DecimalValue =0;
            else
            {
                cellValue.DecimalValue = AggregateValueForPnl(portfolioCode);
            }
                

        }

        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = position.GetResult(MarketData.MarketData.GetCurrentMarketData());
        }

        private decimal AggregateValueForPnl(int portfolioCode)
        {
            decimal valueToReturn = 0;
            var portfolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(portfolioCode);
            int posCount = portfolio.GetPositionsCount();
            for (int posIndex = 0; posIndex < posCount; posIndex++)
            {
                var position = portfolio.GetNthPosition(posIndex);
                if (position == null) continue;
                valueToReturn += position.GetResultInGivenCurrency(MarketData.MarketData.GetCurrentMarketData(),
                    portfolio.PortfolioCurrency.Id);
            }

            foreach (var childPortfolio in portfolio.ChildPortfolios)
            {
                var fx =  MarketData.MarketData.GetCurrentMarketData().GetForex(childPortfolio.PortfolioCurrency.Id, portfolio.PortfolioCurrency.Id) ;
                valueToReturn += AggregateValueForPnl( childPortfolio.PortfolioId)*fx;
            }

            return valueToReturn;
        }
    }
}
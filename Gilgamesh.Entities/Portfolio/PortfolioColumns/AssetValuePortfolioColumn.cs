using System.Net.Sockets;
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


    public class LastPortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour=NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = 0;
        }

        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = MarketData.MarketData.GetCurrentMarketData().GetSpot(position.Instrument.InstrumentId);
        }
    }

    public class CurrencyPortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType=ValueType.String;
            var folio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(portfolioCode);
            cellValue.StringValue = folio.PortfolioCurrency.CurrencyName;
        }

        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.String;
            var currency = UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Get(position.GetCurrencyCode());
            cellValue.StringValue = currency.CurrencyName;
        }
    }
}
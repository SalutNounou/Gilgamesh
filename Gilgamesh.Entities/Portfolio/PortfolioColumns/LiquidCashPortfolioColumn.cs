namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class LiquidCashPortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue =(decimal) PortfolioColumnUtils.AggregateResultsForFolio(this,portfolioCode,true);
        }


        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            var isLiquid = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(position.PortfolioId).IsLiquidFolio;
            if (isLiquid)
            {
                if (position.Instrument.GetInstrumentType() == 'C')
                    cellValue.DecimalValue = position.SecuritiesNumber;
                
            }
            else
            {
                cellValue.DecimalValue = 0;
            }
        }

        public override string Name => "Liquid Cash";
    }
}
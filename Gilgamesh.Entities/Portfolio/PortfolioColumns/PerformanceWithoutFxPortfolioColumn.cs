namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class PerformanceWithoutFxPortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;

            throw new System.NotImplementedException();
        }


        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = ReturnsCalculator.ComputeReturnsForPosition(position);
        }
    }
}
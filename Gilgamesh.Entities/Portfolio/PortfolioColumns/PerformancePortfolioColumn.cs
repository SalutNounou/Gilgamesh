namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public class PerformancePortfolioColumn : PortfolioColumn
    {
        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;

            cellValue.DecimalValue = ReturnsCalculator.CalculateReturnsForFolio(portfolioCode);
        }


        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = ReturnsCalculator.ComputeReturnsForPosition(position);
        }

        public override string Name => "Performance";
    }



    public class ForexPerformancePortfolioColumn : PortfolioColumn
    {
        public override void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            var portfolio = UnitOfWorkFactory.Instance.UnitOfWork.Portfolios.Get(position.PortfolioId);
            cellValue.DecimalValue = ReturnsCalculator.ComputeForexReturns(position, portfolio.PortfolioCurrency.Id);
        }

        public override void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue)
        {
            cellStyle.CellType = ValueType.Decimal;
            cellStyle.NullBehaviour = NullBehaviour.NullOrUndefined;
            cellValue.DecimalValue = 0;
        }

        public override string Name => "Forex Performance";
    }
}
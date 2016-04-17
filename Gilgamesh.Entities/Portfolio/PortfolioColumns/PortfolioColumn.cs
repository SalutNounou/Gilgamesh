using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Globalization;

namespace Gilgamesh.Entities.Portfolio.PortfolioColumns
{
    public abstract class PortfolioColumn
    {
        public abstract void GetPortfolioCell(int portfolioCode, CellStyle cellStyle, CellValue cellValue);
        public abstract void GetPositionCell(Position position, CellStyle cellStyle, CellValue cellValue);

        public string GetStringValue(CellStyle style, CellValue value)
        {
            if (style.CellType == ValueType.Decimal || style.CellType == ValueType.Double ||
                style.CellType == ValueType.Integer)
            {
                if (style.NullBehaviour == NullBehaviour.NullOrUndefined)
                {
                    if (style.CellType == ValueType.Decimal && Math.Abs(value.DecimalValue) <=(decimal) 0.00000000000000000001)
                        return string.Empty;
                    if (style.CellType == ValueType.Double && Math.Abs(value.DoubleValue) <= 0.00000000000000000001)
                        return string.Empty;
                    if (style.CellType == ValueType.Integer && value.IntValue==0)
                        return string.Empty;
                    return GetNormalStringValue(style, value);
                }
                return GetNormalStringValue(style, value);
            }
            return value.StringValue;
        }

        private static string GetNormalStringValue(CellStyle style, CellValue value)
        {
            if (style.CellType == ValueType.Decimal) return value.DecimalValue.ToString(CultureInfo.InvariantCulture);
            if (style.CellType == ValueType.Double)
                return value.DoubleValue.ToString(CultureInfo.InvariantCulture);
            return value.IntValue.ToString();
        }
    }

    public enum ValueType
    {
        Integer,
        String,
        Decimal,
        Double
    }

    public enum NullBehaviour
    {
        NullOrUndefined,
        ShowEverything
    }

    public class CellValue
    {
        public string StringValue { get; set; }
        public decimal DecimalValue { get; set; }
        public int IntValue { get; set; }
        public double DoubleValue { get; set; }
    }

    public class CellStyle
    {
        public ValueType CellType { get; set; }
        public NullBehaviour NullBehaviour { get; set; }

    }
}
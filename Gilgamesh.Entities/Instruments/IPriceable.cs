using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Instruments
{
    public interface IPriceable
    {
        decimal GetTheoreticalValue(IMarketData marketData);
    }
}
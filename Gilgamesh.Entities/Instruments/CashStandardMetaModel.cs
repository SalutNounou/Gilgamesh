using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Instruments
{
    public class CashStandardMetaModel : IMetaModel
    {
        private readonly static string _name = "Standard";
        public string Name => _name;

        public decimal GetPrice(IInstrument instrument, IMarketData marketData)
        {
            var cash = instrument as CashInstrument;
            return cash != null ? 1 : 0;
        }
    }
}
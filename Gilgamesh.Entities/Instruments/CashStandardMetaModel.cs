using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Instruments
{
    public class CashStandardMetaModel : AbstractMetaModel
    {
        private readonly static string _name = "Standard";

        public override string Name
        {
            get { return _name; }
        }

        public override decimal GetPrice(IInstrument instrument, IMarketData marketData)
        {
            var cash = instrument as CashInstrument;
            return cash != null ? 1 : 0;
        }
    }
}
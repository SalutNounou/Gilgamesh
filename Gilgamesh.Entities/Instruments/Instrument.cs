using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Reference;

namespace Gilgamesh.Entities.Instruments
{
    public abstract class Instrument : IInstrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public Reference Reference { get; set; }
        public int CurrencyId { get; set; }
        public int MarketId { get; set; }
        public virtual IMetaModel MetaModel { get; set; }
        public byte [] Rowversion { get; set; }

        public decimal GetTheoreticalValue(IMarketData data)
        {
            return MetaModel?.GetPrice(this, data) ?? 0;
        }
    }
}
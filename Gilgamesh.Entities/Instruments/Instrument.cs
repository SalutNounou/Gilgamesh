using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Reference;

namespace Gilgamesh.Entities.Instruments
{
    public abstract class Instrument : IInstrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public virtual Reference Reference { get; set; }
        public int CurrencyId { get; set; }
        public int MarketId { get; set; }
        public virtual AbstractMetaModel MetaModel { get; set; }
        public byte [] Rowversion { get; set; }
        public abstract char GetInstrumentType();
        public bool QuotationInCents { get; set; }

        public decimal GetTheoreticalValue(IMarketData data)
        {
            return MetaModel?.GetPrice(this, data)*(QuotationInCents?(decimal)1/100:1) ?? 0;
        }
    }
}
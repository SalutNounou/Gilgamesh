using Gilgamesh.Entities.StaticData.Reference;

namespace Gilgamesh.Entities.Instruments
{
    public interface IInstrument : IPriceable
    {
        int InstrumentId { get; set; }
        string Name { get; set; }
        Reference Reference { get; set; }
        int CurrencyId { get; set; }
        int MarketId { get; set; }
        AbstractMetaModel MetaModel { get; set; }
    }
}
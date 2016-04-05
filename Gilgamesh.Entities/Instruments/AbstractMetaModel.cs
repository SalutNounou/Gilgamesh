using System.Collections.Generic;
using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Instruments
{
    public abstract class AbstractMetaModel : IMetaModel
    {
        public int Id { get; set; }

        public byte[] RowVersion { get; set; }
        public abstract string Name { get; }

        public abstract decimal GetPrice(IInstrument instrument, IMarketData marketData);
        public List<Instrument> Instruments { get; set; }
    }
}
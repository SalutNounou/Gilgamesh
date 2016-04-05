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


    public class ShareStandardMetaModel : AbstractMetaModel
    {
        private readonly static string _name = "Standard";

        public override string Name
        {
            get { return _name; }
        }

        public override decimal GetPrice(IInstrument instrument, IMarketData marketData)
        {
            var share = instrument as Share;
            return marketData.GetSpot(instrument.InstrumentId);
        }
    }
}
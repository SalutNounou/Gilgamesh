using System.Security.Cryptography.X509Certificates;
using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Instruments
{
    public interface IMetaModel
    {
        int Id { get; set; }
        string Name { get; }
        decimal GetPrice(IInstrument instrument, IMarketData marketData);
        byte[] RowVersion { get; set; }
    }
}
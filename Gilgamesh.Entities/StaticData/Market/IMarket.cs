using System.Security.Cryptography.X509Certificates;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.Entities.StaticData.Market
{
    public interface IMarket : ICalendar
    {
        
        string MarketName { get; set; }
        string MarketAcronym { get; set; }
        int MarketCurrencyId { get; set; }
    }
}
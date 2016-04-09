using System.Collections;
using System.Collections.Generic;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData;

namespace Gilgamesh.Entities.Portfolio
{
    public interface IPosition
    {
        int PositionId { get; set; } 
        int PortfolioId { get; set; }
        Instrument Instrument { get; set; }
        decimal SecuritiesNumber { get; set; }
        IEnumerable<Trade> Trades { get; set; }
        decimal GetAssetValue(IMarketData marketData);
        decimal GetResult(IMarketData marketData);
        int GetCurrencyCode();
         

    }
}
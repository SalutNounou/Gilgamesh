using System;
using System.Collections.Generic;
using System.Linq;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.MarketData;


namespace Gilgamesh.Entities.Portfolio
{
    public class Position : IPosition
    {
        public int PositionId { get; set; }
        public int PortfolioId { get; set; }
        public Instrument Instrument { get; set; }
        public decimal SecuritiesNumber { get; set; }

        public IEnumerable<Trade> Trades { get; set; }



        public decimal GetAssetValue(IMarketData marketData)
        {
            return SecuritiesNumber*Instrument.GetTheoreticalValue(marketData);
        }

        public decimal GetResult(IMarketData marketData)
        {
            
            var realizedPnL = -1* Trades.Sum(t => t.Price*t.Quantity + t.Fees);
            var potentialPnl = GetAssetValue(marketData);
            return realizedPnL+potentialPnl;
        }

        public int GetCurrencyCode()
        {
            return Instrument.CurrencyId;
        }
    }



    
}
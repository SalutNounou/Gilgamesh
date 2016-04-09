using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        IEnumerable<Trade> GetTrades();
        decimal GetAssetValue(IMarketData marketData);
        decimal GetResult(IMarketData marketData);
        int GetCurrencyCode();

    }


    public class Position : IPosition
    {
        public int PositionId { get; set; }
        public int PortfolioId { get; set; }
        public Instrument Instrument { get; set; }
        public decimal SecuritiesNumber { get; set; }

        public IEnumerable<Trade> GetTrades()
        {
            return
                UnitOfWorkFactory.Instance.UnitOfWork.Trades.Find(
                    t =>
                        (t.PortfolioId == PortfolioId && t.Instrument.InstrumentId == Instrument.InstrumentId &&
                         t.Status == Status.Live));
        }

        public decimal GetAssetValue(IMarketData marketData)
        {
            return SecuritiesNumber*Instrument.GetTheoreticalValue(marketData);
        }

        public decimal GetResult(IMarketData marketData)
        {
            var trades = GetTrades();
            var realizedPnL = -1* trades.Sum(t => t.Price*t.Quantity + t.Fees);
            var potentialPnl = GetAssetValue(marketData) * Math.Sign(SecuritiesNumber);
            return realizedPnL+potentialPnl;
        }

        public int GetCurrencyCode()
        {
            return Instrument.CurrencyId;
        }
    }
}
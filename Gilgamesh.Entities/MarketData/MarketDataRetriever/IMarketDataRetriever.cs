using System.Collections.Generic;
using System;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.StaticData.Currency;
namespace Gilgamesh.Entities.MarketData.MarketDataRetriever
{
    public interface IMarketDataRetriever
    {
        decimal GetLast(string ticker);
        decimal GetLast(IInstrument instrument);
        List<Fixings> GetLast(List<string> ticker);
        List<Fixings> GetLast(List<IInstrument> instruments);
        List<Fixings> GetHistoricalFixings(string ticker, DateTime dateFrom, DateTime dateTo);
        List<Fixings> GetHistoricalFixings(IInstrument instrument, DateTime dateFrom, DateTime dateTo);
        decimal GetForexLast(string currencyFrom, string currencyTo );
        List<Fixings> GetForexHistoricalFixings(Currency currencyFrom, Currency currencyTo, DateTime dateFrom, DateTime dateTo);
        Fixings GetForexAtDate(string currencyFrom, string currencyTo, DateTime date);
    }
}


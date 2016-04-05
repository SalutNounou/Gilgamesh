using System;

namespace Gilgamesh.Entities.MarketData
{
    public interface IMarketData
    {
        DateTime GetDate();
        decimal GetSpot(int instrumentId);
        decimal GetForex(int currencyFrom, int currencyTo);
    }
}
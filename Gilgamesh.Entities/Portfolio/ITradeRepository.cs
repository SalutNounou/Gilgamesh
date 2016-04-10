using System;
using System.Collections;
using System.Collections.Generic;

namespace Gilgamesh.Entities.Portfolio
{
    public interface ITradeRepository:IRepository<Trade>
    {
        IEnumerable<Trade> GetLiveTradeForFolioAndInstrumentAtDate(int folioId, int instrumentId,DateTime date);
        IEnumerable<int> GetInstrumentsInPortfolio(int portfolioId);

    }
}
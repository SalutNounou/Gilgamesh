using System;
using System.Collections.Generic;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.DataAccess
{
    public class TradeRepository : Repository<Trade>, ITradeRepository
    {
        public TradeRepository(IDbContext context) : base(context)
        {
            
        }


        public IEnumerable<Trade> GetLiveTradeForFolioAndInstrumentAtDate(int folioId, int instrumentId, DateTime date)
        {
            return Find(t=>t.PortfolioId==folioId && t.Instrument.InstrumentId==instrumentId &&t.Status==Status.Live && t.TradeDate<=date);
        }
    }
}
using System;
using Gilgamesh.Entities;
using Gilgamesh.Entities.MarketData;
using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Market;
using Gilgamesh.Entities.Instruments;
using Gilgamesh.Entities.Portfolio;

namespace Gilgamesh.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            CurrencyRepository = new Repository<Currency>(_context);
            CommonNonWorkingDayRepository = new Repository<CommonNonWorkingDay>(_context);
            References = new Repository<Reference>(_context);
            ReferenceTypes = new Repository<ReferenceType>(_context);
            Markets = new Repository<Market>(_context);
            Fixings = new Repository<Fixings>(_context);
            Instruments = new Repository<Instrument>(_context);
            Trades = new TradeRepository(_context);
        }

        public IRepository<Currency> CurrencyRepository { get; }
        public IRepository<CommonNonWorkingDay> CommonNonWorkingDayRepository { get; }
        public IRepository<Reference> References { get; }
        public IRepository<ReferenceType> ReferenceTypes { get; }
        public IRepository<Market> Markets { get; }
        public IRepository<Fixings> Fixings { get; }
        public IRepository<Instrument> Instruments { get; }
        public ITradeRepository Trades { get; }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException)
            {
                Rollback();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Rollback()
        {
            _context.Rollback();
        }
    }
}

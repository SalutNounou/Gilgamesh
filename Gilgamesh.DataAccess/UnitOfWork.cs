using System;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.DataAccess
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {

        private readonly IDbContext _context;

        public UnitOfWork(IDbContext context)
        {
            _context = context;
            CurrencyRepository = new Repository<Currency>(_context);
            CommonNonWorkingDayRepository = new Repository<CommonNonWorkingDay>(_context);
        }

        public IRepository<Currency> CurrencyRepository { get;  }
        public IRepository<CommonNonWorkingDay> CommonNonWorkingDayRepository { get; }



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

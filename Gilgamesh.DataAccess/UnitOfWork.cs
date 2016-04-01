using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationContext _context;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            CurrencyRepository = new Repository<CurrencyEntity>(_context);
        }

        public IRepository<CurrencyEntity> CurrencyRepository { get;}

        

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

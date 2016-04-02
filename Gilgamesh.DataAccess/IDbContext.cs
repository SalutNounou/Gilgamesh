using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Gilgamesh.DataAccess
{
    public interface IDbContext : IDisposable
    {
        IQueryable<T> Find<T>() where T : class;
        DbChangeTracker ChangeTracker { get; }
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Rollback();
    }
}
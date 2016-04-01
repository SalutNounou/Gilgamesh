using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.DataAccess
{
    public class ApplicationContext : DbContext, IDbContext
    {

        public DbSet<CurrencyEntity> Currencies { get; set; }
        


        public IQueryable<T> Find<T>() where T : class
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new BankHolidayConfiguration());


        }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }


    public class CurrencyConfiguration : EntityTypeConfiguration<CurrencyEntity>
    {
        public CurrencyConfiguration()
        {
            HasKey(a => a.CurrencyEntityId);
            Property(a => a.Name).HasMaxLength(3);
            Property(a => a.RowVersion).IsRowVersion();
            HasMany(a => a.BankHolidays).WithRequired(c => c.Currency);
        }
    }

    public class BankHolidayConfiguration : EntityTypeConfiguration<BankHoliday>
    {
        public BankHolidayConfiguration()
        {
            HasKey(c => c.BankHolidayEntityId);
            Property(c => c.RowVersion).IsRowVersion();
            HasRequired(c => c.Currency).WithMany(a => a.BankHolidays);
        }
    }

}

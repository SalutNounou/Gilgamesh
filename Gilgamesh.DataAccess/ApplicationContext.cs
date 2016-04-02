using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities.StaticData.Market;

namespace Gilgamesh.DataAccess
{
    public class ApplicationContext : DbContext, IDbContext
    {

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CommonNonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<ReferenceType> ReferenceTypes { get; set; }
        public DbSet<Market> Markets { get; set; }

        public IQueryable<T> Find<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
            modelBuilder.Configurations.Add(new MarketConfiguration());
            modelBuilder.Configurations.Add(new BankHolidayConfiguration());
            modelBuilder.Configurations.Add(new NonWorkingDayConfiguration());
            modelBuilder.Configurations.Add(new ReferenceConfiguration());
            modelBuilder.Configurations.Add(new ReferenceTypeConfiguration());
        }

        public void Rollback()
        {
            ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }


    

    public class BankHolidayConfiguration : EntityTypeConfiguration<BankHoliday>
    {
        public BankHolidayConfiguration()
        {
            HasKey(c => c.BankHolidayId);
            Property(c => c.RowVersion).IsRowVersion();
            HasRequired(c => c.Calendar);
        }
    }

    public class NonWorkingDayConfiguration : EntityTypeConfiguration<CommonNonWorkingDay>
    {
        public NonWorkingDayConfiguration()
        {
            HasKey(c => c.CommmonNonWorkingDayId);
            Property(c => c.RowVersion).IsRowVersion();
        }
    }

    public class ReferenceConfiguration : EntityTypeConfiguration<Reference>
    {
        public ReferenceConfiguration()
        {
            HasKey(c => c.ReferenceId);
            Property(c => c.Name).HasMaxLength(24);
            Property(c => c.RowVersion).IsRowVersion();
            Property(c => c.ReferecenceTypeId).IsRequired();
            Property(c => c.InstrumentId).IsRequired();
        }
    }

    public class ReferenceTypeConfiguration : EntityTypeConfiguration<ReferenceType>
    {
        public ReferenceTypeConfiguration()
        {
            HasKey(c => c.ReferenceTypeId);
            Property(c => c.RowVersion).IsRowVersion();
            Property(c => c.Name).HasMaxLength(16);
            Property(c => c.ReferenceTypeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }

    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(a => a.CurrencyName).HasMaxLength(3);
            Property(a => a.RowVersion).IsRowVersion();
        }
    }

    public class MarketConfiguration : EntityTypeConfiguration<Market>
    {
        public MarketConfiguration()
        {
            HasKey(m => m.Id);
            Property(m => m.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(m => m.RowVersion).IsRowVersion();
            Property(m => m.MarketName).HasMaxLength(64).IsRequired();
            Property(m => m.MarketAcronym).HasMaxLength(8).IsRequired();
            Property(m => m.MarketCurrencyId).IsRequired();

        }
    }


}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using Gilgamesh.Entities.StaticData.Currency;
using Gilgamesh.Entities.StaticData.Reference;

namespace Gilgamesh.DataAccess
{
    public class ApplicationContext : DbContext, IDbContext
    {

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CommonNonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<ReferenceType> ReferenceTypes { get; set; }


        public IQueryable<T> Find<T>() where T : class
        {
            return Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new CurrencyConfiguration());
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


    public class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            HasKey(a => a.CurrencyId);
            Property(c => c.CurrencyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(a => a.Name).HasMaxLength(3);
            Property(a => a.RowVersion).IsRowVersion();
            
        }
    }

    public class BankHolidayConfiguration : EntityTypeConfiguration<BankHoliday>
    {
        public BankHolidayConfiguration()
        {
            HasKey(c => c.BankHolidayId);
            Property(c => c.RowVersion).IsRowVersion();
            HasRequired(c => c.Currency);
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


}

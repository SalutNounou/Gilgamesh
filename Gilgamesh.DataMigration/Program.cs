using System.Data.Entity;
using System.Linq;
using Gilgamesh.DataAccess;
using Gilgamesh.Entities;

namespace Gilgamesh.DataMigration
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationContext>());
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;
                CurrencyImporter.ImportCurrencies();
            }
        }
    }
}

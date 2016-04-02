using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Gilgamesh.DataAccess;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData;
using System.Data.Entity;

namespace Gilgamesh.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AddCurrency();
        }


        private  static void  AddCurrency()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;
                var currency = new Currency(new List<BankHoliday> { new BankHoliday { Day = new DateTime(2016, 5, 1) } })
                {
                    CurrencyId = 2,
                    Name = "USD"
                };

                UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Add(currency);
                UnitOfWorkFactory.Instance.UnitOfWork.Complete();



            }
        }
    }
}

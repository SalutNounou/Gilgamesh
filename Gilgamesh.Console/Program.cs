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
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationContext>());
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;

                var currency = UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Get(1);
                var date = new DateTime(2016, 4, 1);
                bool resut = currency.IsABankHoliday(date);
                int test = 0;

            }
        }
    }
}

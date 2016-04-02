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
            using (var unitOfWork = new UnitOfWork(new ApplicationContext()))
            {
                UnitOfWorkFactory.Instance.UnitOfWork = unitOfWork;
                var market = UnitOfWorkFactory.Instance.UnitOfWork.Markets.Get(100);
                var date = new DateTime(2016, 3, 22);
                bool resut = market.IsABankHoliday(date);
                int test = 0;
            }



        }
    }
}

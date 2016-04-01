using System.Linq;
using Gilgamesh.Entities;

namespace Gilgamesh.Domain.StaticData
{
     public class CurrencyFactory :ICurrencyFactory
    {
         public ICurrency GetCurrency(int? currencyId = null)
         {
            if(currencyId==0)return new Currency();
             var currency =
                 UnitOfWorkFactory.Instance.GetUnitOfWork()
                     .CurrencyRepository.Find(c => c.CurrencyEntityId == currencyId)
                     .FirstOrDefault();
             if (currency == null) return null;
             return new Currency(currency.BankHolidays) {CurrencyId=(int)currencyId, Name = currency.Name };
         }

         public ICurrency GetCurrency(string name)
         {
            if (name == string.Empty) return new Currency();
            var currency =
                UnitOfWorkFactory.Instance.GetUnitOfWork()
                    .CurrencyRepository.Find(c => c.Name == name)
                    .FirstOrDefault();
            if (currency == null) return null;
            return new Currency(currency.BankHolidays) { CurrencyId = currency.CurrencyEntityId, Name = currency.Name };
        }
    }
}

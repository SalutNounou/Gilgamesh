using System;
using System.Collections.Generic;
using Gilgamesh.Entities;
using Gilgamesh.Entities.StaticData.Currency;

namespace Gilgamesh.DataMigration
{
    public static class CurrencyImporter
    {

        private static readonly Dictionary<int, string> Currencies =
            new Dictionary<int, string>
            {
                {1,"USD" },
                {2,"EUR" },
                {3,"CHF" },
                {4,"GBP" },
                {5,"CAD" },
                {6,"SGD" },
                {7,"JPY" },
                {8,"AUS" },
                {9,"CNY" }
            };
           

        public static void ImportCurrencies()
        {

            UnitOfWorkFactory.Instance.UnitOfWork.CommonNonWorkingDayRepository.AddRange(GetCommonNonWorkingDays());


            for (int i = 1; i <= Currencies.Count;i++)
            {
                var currency = GetCurrency(i);
                UnitOfWorkFactory.Instance.UnitOfWork.CurrencyRepository.Add(currency);
            }
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }


        public static Currency GetCurrency(int i)
        {
            return Currencies.ContainsKey(i)?new Currency
            {
                Id = i,
                CurrencyName = Currencies[i]
            }:null;
        }

        public static List<CommonNonWorkingDay> GetCommonNonWorkingDays()
        {
            var bankHolidays = new List<CommonNonWorkingDay>();
            for (int currentYear = 2010; currentYear <= 2030; currentYear++)
            {
              DateTime currentDate = new DateTime(currentYear,1,1);   
                DateTime endDate = new DateTime(currentYear,12,31);
                while (currentDate <= endDate)
                {
                    if( IsABankHolidayDay(currentDate)) bankHolidays.Add(new CommonNonWorkingDay { Day = currentDate});
                    currentDate=currentDate.AddDays(1);
                }
            }
            return bankHolidays;
        }

        private static bool IsABankHolidayDay(DateTime toTest)
        {
            return /*toTest.DayOfWeek == DayOfWeek.Saturday || toTest.DayOfWeek == DayOfWeek.Sunday
                   ||*/ (toTest.Day == 1 && (toTest.Month == 1 || toTest.Month == 5))
                   || (toTest.Day == 25 && (toTest.Month == 12));
        }
    }

    
}
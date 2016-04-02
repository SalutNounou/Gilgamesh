using System;
using System.Collections.Generic;
using System.Linq;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public class Currency : Calendar, ICurrency
    {
        
        public string CurrencyName { get; set; }
        



        public Currency() : base()
        {

        }

        public Currency(List<BankHoliday> bankHolidays) : base(bankHolidays)
        {

        }

        public Currency(List<BankHoliday> bankholidays, List<CommonNonWorkingDay> commomnNonWorkingDays) : base(commomnNonWorkingDays, bankholidays)
        {

        }

    }
}

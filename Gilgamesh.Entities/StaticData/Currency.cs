using System;
using System.Collections.Generic;
using System.Linq;


namespace Gilgamesh.Entities.StaticData
{
    public class Currency :Calendar, ICurrency
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        private List<BankHoliday> _bankHolidays;
        public virtual List<BankHoliday> BankHolidays
        { get { return _bankHolidays; } private set { _bankHolidays = value; } }
        public byte[] RowVersion { get; set; }



        public Currency():this(new List<BankHoliday>())
        {
            
        }

        public Currency(List<BankHoliday> bankHolidays)
        {
            _bankHolidays = bankHolidays;
        }


        public Currency(List<BankHoliday> bankholidays, List<CommonNonWorkingDay> commomnNonWorkingDays): base(commomnNonWorkingDays)
        {
            _bankHolidays = bankholidays;
            
        }

        public override bool IsABankHoliday(DateTime day)
        {
            return IsCommonNonWorkingDay(day) || BankHolidays.Any(d => d.Day.ToShortDateString() == day.ToShortDateString());
        }
    }
}

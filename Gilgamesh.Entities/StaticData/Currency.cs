using System;
using System.Collections.Generic;
using System.Linq;


namespace Gilgamesh.Entities.StaticData
{
    public class Currency : ICurrency
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        private List<BankHoliday> _bankHolidays;
        public virtual List<BankHoliday> BankHolidays
        { get { return _bankHolidays; } private set { _bankHolidays = value; } }
        public byte[] RowVersion { get; set; }



        public Currency()
        {
            _bankHolidays = new List<BankHoliday>();
        }


        public Currency(List<BankHoliday> bankholidays)
        {
            _bankHolidays = bankholidays;
        }

        public bool IsABankHoliday(DateTime day)
        {
            return BankHolidays.Any(d => d.Day.ToShortDateString() == day.ToShortDateString());
        }

        public DateTime AddDays(DateTime startingDate, int howManyDays)
        {
            if (howManyDays == 0) return startingDate;
            int count = 0;
            var currentDate = startingDate;
            while (count != howManyDays)
            {
                do
                {
                    currentDate = currentDate.AddDays(1 * Math.Sign(howManyDays));
                } while (IsABankHoliday(currentDate));
                count += 1 * Math.Sign(howManyDays);
            }
            return currentDate;
        }

    }
}

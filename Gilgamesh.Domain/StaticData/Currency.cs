using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Gilgamesh.Entities.StaticData;

namespace Gilgamesh.Domain.StaticData
{
    public class Currency : ICurrency
    {
        private readonly List<BankHoliday> _bankHolidays;

        public Currency()
        {
            _bankHolidays = new List<BankHoliday>();
        }


        public Currency(List<BankHoliday> bankholdays)
        {
            _bankHolidays = bankholdays;
        }

        public int CurrencyId { get; set; }
        public string Name { get; set; }

        public bool IsABankHoliday(DateTime day)
        {
            return _bankHolidays.Any(d=>d.Day.ToShortDateString()==day.ToShortDateString());
        }

        public DateTime AddDays(DateTime startingDate, int howManyDays)
        {
            if(howManyDays==0)return startingDate;
            int count = 0;
            var currentDate = startingDate;
            while (count != howManyDays)
            {
                do
                {
                    currentDate = currentDate.AddDays(1*Math.Sign(howManyDays));
                } while (IsABankHoliday(currentDate));
                count += 1*Math.Sign(howManyDays);
            }
            return currentDate;
        }


    }
}

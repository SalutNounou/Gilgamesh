using System;
using System.Collections.Generic;
using System.Linq;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public abstract class Calendar : ICalendar
    {

        public int Id { get; set; }
        public byte[] RowVersion { get; set; }
        protected static List<CommonNonWorkingDay> NonWorkingDays { get; private set; }


        private List<BankHoliday> _bankHolidays;
        public virtual List<BankHoliday> BankHolidays
        { get { return _bankHolidays; } private set { _bankHolidays = value; } }


        protected Calendar() : this(UnitOfWorkFactory.Instance.GetUnitOfWork().CommonNonWorkingDayRepository.GetAll().ToList())
        {

        }

        protected Calendar(List<CommonNonWorkingDay> nonWorkingDays) : this(nonWorkingDays, new List<BankHoliday>())
        {

        }

        protected Calendar(List<BankHoliday> bankHolidays) : this(UnitOfWorkFactory.Instance.GetUnitOfWork().CommonNonWorkingDayRepository.GetAll().ToList(), bankHolidays)
        {

        }

        protected Calendar(List<CommonNonWorkingDay> nonWorkingDays, List<BankHoliday> bankHolidays)
        {
            NonWorkingDays = nonWorkingDays;
            BankHolidays = bankHolidays;
        }

        public bool IsABankHoliday(DateTime day)
        {
            return IsCommonNonWorkingDay(day) || BankHolidays.Any(d => d.Day.ToShortDateString() == day.ToShortDateString());
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

        public bool IsCommonNonWorkingDay(DateTime day)
        {
            return day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday || NonWorkingDays.Any(d => d.Day == day);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public abstract class Calendar : ICalendar
    {
        public  bool IsCommonNonWorkingDay(DateTime day)
        {
            return day.DayOfWeek==DayOfWeek.Saturday || day.DayOfWeek ==DayOfWeek.Sunday|| NonWorkingDays.Any(d=>d.Day==day);
        }

        protected static  List<CommonNonWorkingDay> NonWorkingDays { get; private set; }

        protected Calendar():this(UnitOfWorkFactory.Instance.GetUnitOfWork().CommonNonWorkingDayRepository.GetAll().ToList())
        {
            
        }

        protected Calendar(List<CommonNonWorkingDay> nonWorkingDays)
        {
            NonWorkingDays = nonWorkingDays;
        }

        public virtual bool IsABankHoliday(DateTime day)
        {
            return IsCommonNonWorkingDay(day);
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
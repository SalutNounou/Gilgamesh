using System;

namespace Gilgamesh.Entities.StaticData
{
    public interface ICalendar
    {
        bool IsCommonNonWorkingDay(DateTime day);
        bool IsABankHoliday(DateTime day);
        DateTime AddDays(DateTime startingDate, int howManyDays);
    }
}
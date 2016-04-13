using System;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public interface ICalendar
    {
        int Id { get; set; }
        bool IsCommonNonWorkingDay(DateTime day);
        bool IsABankHoliday(DateTime day);
        DateTime AddDays(DateTime startingDate, int howManyDays);
        DateTime GetNextWorkingDay(DateTime input);
        DateTime GetPreviousWorkingDay(DateTime input);
    }
}
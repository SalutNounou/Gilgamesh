using System;

namespace Gilgamesh.Entities.StaticData
{
    public interface ICurrency
    {
        string Name { get; set; }
        bool IsABankHoliday(DateTime day);
        DateTime AddDays(DateTime startingDate, int howManyDays);
    }
}
using System;

namespace Gilgamesh.Domain.StaticData
{
    public interface ICurrency
    {
        bool IsABankHoliday(DateTime day);
        DateTime AddDays(DateTime startingDate, int howManyDays);
    }
}
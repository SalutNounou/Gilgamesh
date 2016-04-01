using System;

namespace Gilgamesh.Entities.StaticData
{
    public class BankHoliday
    {
         public int BankHolidayEntityId { get; set; }
         public CurrencyEntity Currency { get; set; }
         public DateTime Day { get; set; }
         public byte[] RowVersion { get; set; }
    }
}
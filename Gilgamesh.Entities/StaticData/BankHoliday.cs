using System;

namespace Gilgamesh.Entities.StaticData
{
    public class BankHoliday
    {
         public int BankHolidayId { get; set; }
         public Currency Currency { get; set; }
         public DateTime Day { get; set; }
         public byte[] RowVersion { get; set; }
    }
}
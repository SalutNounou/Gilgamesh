using System.Collections.Generic;


namespace Gilgamesh.Entities.StaticData
{
    public class CurrencyEntity
    {
        public int CurrencyEntityId { get; set; }
        public string Name { get; set; }
        public virtual List<BankHoliday> BankHolidays { get; set; }
        public byte[] RowVersion { get; set; }
    }
}

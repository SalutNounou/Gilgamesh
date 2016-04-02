using System;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public class BankHoliday 
    {
        protected bool Equals(BankHoliday other)
        {
            return BankHolidayId == other.BankHolidayId && Equals(Currency, other.Currency) && Day.Equals(other.Day) && Equals(RowVersion, other.RowVersion);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = BankHolidayId;
                hashCode = (hashCode*397) ^ (Currency != null ? Currency.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Day.GetHashCode();
                hashCode = (hashCode*397) ^ (RowVersion != null ? RowVersion.GetHashCode() : 0);
                return hashCode;
            }
        }

        public int BankHolidayId { get; set; }
        public Currency Currency { get; set; }
        public DateTime Day { get; set; }
        public byte[] RowVersion { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BankHoliday) obj);
        }
    }
}
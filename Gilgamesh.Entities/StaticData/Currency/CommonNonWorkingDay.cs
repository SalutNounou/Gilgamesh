using System;

namespace Gilgamesh.Entities.StaticData.Currency
{
    public class CommonNonWorkingDay
    {
        protected bool Equals(CommonNonWorkingDay other)
        {
            return CommmonNonWorkingDayId == other.CommmonNonWorkingDayId && Day.Equals(other.Day) && Equals(RowVersion, other.RowVersion);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CommmonNonWorkingDayId;
                hashCode = (hashCode*397) ^ Day.GetHashCode();
                hashCode = (hashCode*397) ^ (RowVersion?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public int CommmonNonWorkingDayId { get; set; }
        public DateTime Day { get; set; }
        public byte[] RowVersion { get; set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CommonNonWorkingDay) obj);
        }
    }
}
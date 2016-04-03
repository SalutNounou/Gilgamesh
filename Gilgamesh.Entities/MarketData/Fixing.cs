using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilgamesh.Entities.MarketData
{
    public class Fixings
    {

        public int FixingId { get; set; }
        public int InstrumentId { get; set; }
        public string Reference { get; set; }
        public decimal Last { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Open { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal AdjustedClose { get; set; }
        public decimal Theroretical { get; set; }
        public DateTime Fixingdate { get; set; }
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            return String.Format("Fixings : Id = {0}, InstrumentId={1} Reference = {2}, FixingDate = {3}, Last = {4}, High = {5}, Low = {6}, Open = {7}, Close = {8}, Volume = {9}, AdjustedClose = {10}, Theoretical = {11}",FixingId, InstrumentId,Reference, Fixingdate.ToShortDateString(), Last, High, Low, Open, Close, Volume, AdjustedClose, Theroretical);
        }

     #region Equality Members

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fixings) obj);
        }


        protected bool Equals(Fixings other)
        {
            return FixingId == other.FixingId && InstrumentId == other.InstrumentId && string.Equals(Reference, other.Reference) && Last == other.Last && High == other.High && Low == other.Low && Open == other.Open && Close == other.Close && Volume == other.Volume && AdjustedClose == other.AdjustedClose && Theroretical == other.Theroretical && Fixingdate.Equals(other.Fixingdate) && Equals(RowVersion, other.RowVersion);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = FixingId;
                hashCode = (hashCode * 397) ^ InstrumentId;
                hashCode = (hashCode * 397) ^ (Reference != null ? Reference.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ Last.GetHashCode();
                hashCode = (hashCode * 397) ^ High.GetHashCode();
                hashCode = (hashCode * 397) ^ Low.GetHashCode();
                hashCode = (hashCode * 397) ^ Open.GetHashCode();
                hashCode = (hashCode * 397) ^ Close.GetHashCode();
                hashCode = (hashCode * 397) ^ Volume.GetHashCode();
                hashCode = (hashCode * 397) ^ AdjustedClose.GetHashCode();
                hashCode = (hashCode * 397) ^ Theroretical.GetHashCode();
                hashCode = (hashCode * 397) ^ Fixingdate.GetHashCode();
                hashCode = (hashCode * 397) ^ (RowVersion != null ? RowVersion.GetHashCode() : 0);
                return hashCode;
            }

        }

        #endregion Equality Members
    }
}

using System;
using Gilgamesh.Entities.Instruments;

namespace Gilgamesh.Entities.StaticData.Reference
{
    public class Reference : IReference
    {
       

        public int ReferenceId { get; set; }
        public string Name { get; set; }
        public int ReferecenceTypeId { get; set; }
        public Byte[] RowVersion { get; set; }
        public Instrument Instrument { get; set; }
        
        #region Equality members

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Reference) obj);
        }

        protected bool Equals(Reference other)
        {
            return ReferenceId == other.ReferenceId && string.Equals(Name, other.Name) && ReferecenceTypeId == other.ReferecenceTypeId && Equals(RowVersion, other.RowVersion) && Equals(Instrument, other.Instrument);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ReferenceId;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ ReferecenceTypeId;
                hashCode = (hashCode * 397) ^ (RowVersion != null ? RowVersion.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Instrument != null ? Instrument.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion Equality members
    }
}
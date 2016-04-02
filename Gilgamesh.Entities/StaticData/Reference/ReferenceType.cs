using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilgamesh.Entities.StaticData.Reference
{
    public class ReferenceType
    {

        public int ReferenceTypeId { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }

        #region Equality members
        protected bool Equals(ReferenceType other)
        {
            return ReferenceTypeId == other.ReferenceTypeId && string.Equals(Name, other.Name) && Equals(RowVersion, other.RowVersion);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = ReferenceTypeId;
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (RowVersion != null ? RowVersion.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ReferenceType) obj);
        }

        #endregion Equality members
    }
}

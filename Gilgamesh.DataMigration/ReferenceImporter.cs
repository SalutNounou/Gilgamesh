using Gilgamesh.Entities.StaticData.Reference;
using Gilgamesh.Entities;
namespace Gilgamesh.DataMigration
{
    public class ReferenceImporter
    {
        public static void ImportReferences()
        {
            ReferenceType refType = new ReferenceType {Name = "YAHOO", ReferenceTypeId = 1};
            UnitOfWorkFactory.Instance.UnitOfWork.ReferenceTypes.Add(refType);
            UnitOfWorkFactory.Instance.UnitOfWork.Complete();
        }
    }
}
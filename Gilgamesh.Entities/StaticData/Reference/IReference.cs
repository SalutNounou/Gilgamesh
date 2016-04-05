using Gilgamesh.Entities.Instruments;

namespace Gilgamesh.Entities.StaticData.Reference
{
    public interface IReference
    {
        string Name { get; set; }
        int ReferecenceTypeId { get; set; }
        Instrument Instrument { get; set; }
    }
}
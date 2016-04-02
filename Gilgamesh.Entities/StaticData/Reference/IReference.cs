namespace Gilgamesh.Entities.StaticData.Reference
{
    public interface IReference
    {
        string Name { get; set; }
        int ReferecenceTypeId { get; set; }
        int InstrumentId { get; set; }
    }
}
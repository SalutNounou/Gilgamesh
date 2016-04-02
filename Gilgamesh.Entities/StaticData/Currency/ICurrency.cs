namespace Gilgamesh.Entities.StaticData.Currency
{
    public interface ICurrency : ICalendar
    {
        string Name { get; set; }
    }
}
namespace Gilgamesh.Entities.StaticData.Currency
{
    public interface ICurrency : ICalendar
    {
        string CurrencyName { get; set; }
    }
}
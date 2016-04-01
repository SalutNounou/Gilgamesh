namespace Gilgamesh.Domain.StaticData
{
    public interface ICurrencyFactory
    {
        ICurrency GetCurrency(int? currencyId = null);
        ICurrency GetCurrency(string name);
    }
}
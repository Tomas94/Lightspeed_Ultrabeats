public class Currency
{
    int currency;

    public Currency(int _actualCurrency) => currency = _actualCurrency;

    public int SpentResource(int quantity)
    {
        if (currency > quantity) currency -= quantity;            
        return currency;
    }

    public int GainResource(int quantity)
    {
        var currencyGained = quantity * 0.8f * 0.7f;
        currency += (int)currencyGained;
        return currency;
    }
}

public class Currency
{
    public int _actualCurrency;

    public Currency(int actualCurrency) => _actualCurrency = actualCurrency;

    public void SpentResource(int quantity)
    {
        if (_actualCurrency < quantity) return;
        _actualCurrency -= quantity;
    }

    public void GainResource(int quantity)
    {
        var currencyGained = quantity * 0.8f * 0.7f;
        _actualCurrency += (int)currencyGained;
    }
}

namespace CurrencyConverter
{
    public interface ICurrencyConverter
    {
        Money AddAndReturnInFirstCurrency(Money first, Money second);
        Money SubstractAndReturnInFirstCurrency(Money first, Money second);
        Money Convert(Money money, Currency currency);
    }
}

namespace CurrencyConverter
{
    public record Money
    {
        public decimal Count { get; set; }
        public Currency Currency { get; set; }
    }
}

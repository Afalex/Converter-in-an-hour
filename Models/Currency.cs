namespace CurrencyConverter
{
    public record Currency
    {
        public string Name { get; set; }
        public decimal? Rate { get; set; }
        public Currency BaseCurrency { get; set; }

        public Currency(string name, decimal? rate = null, Currency baseCurrency = null)
        {
            Name = name;
            Rate = rate;
            BaseCurrency = baseCurrency;
        }

        public override string ToString()
        {
            return $"{Name}:{Rate}";
        }

    }
}

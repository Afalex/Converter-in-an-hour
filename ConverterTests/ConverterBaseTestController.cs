using CurrencyConverter;
using System.Collections.Generic;

namespace ConverterTests
{
    public abstract class ConverterBaseTestController
    {
        /*Dictinary - для более быстрого нахождения нужной валюты*/
        internal Dictionary<string, Currency> currencies;

        #region data seed
        public ConverterBaseTestController()
        {
            var rubCurrency = new Currency("RUB");
            var usdCurrency = new Currency("USD", rate: 72.219M, rubCurrency);
            var cnyCurrency = new Currency("CNY", rate: 0.15M, usdCurrency);
            var eurCurrency = new Currency("EUR", rate: 7.57M, cnyCurrency);

            rubCurrency.Rate = 0.012M;
            rubCurrency.BaseCurrency = eurCurrency;

            currencies = new Dictionary<string, Currency>
            {
                { rubCurrency.Name, rubCurrency },
                { usdCurrency.Name, usdCurrency },
                { cnyCurrency.Name, cnyCurrency },
                { eurCurrency.Name, eurCurrency }
            };
        }
        #endregion
    }
}

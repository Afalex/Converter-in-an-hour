using System;
using System.Collections.Generic;
using System.Linq;

namespace CurrencyConverter
{
    public class Converter : ICurrencyConverter
    {
        public Money AddAndReturnInFirstCurrency(Money first, Money second)
        {
            return Operation(first, second, (first, second) => first.Count += second.Count);
        }

        public Money SubstractAndReturnInFirstCurrency(Money first, Money second)
        {
            return Operation(first, second, (first, second) => first.Count -= second.Count);
        }

        private Money Operation(Money first, Money second, Action<Money, Money> operation)
        {
            if (first.Currency != second.Currency)
            {
                var firstMoneyInFirstCurrency = Convert(second, first.Currency);
                operation(first, firstMoneyInFirstCurrency);
                return first;
            }
            return new Money() { Currency = first.Currency, Count = first.Count + second.Count };
        }

        public Money Convert(Money money, Currency targetCurrency)
        {
            List<Currency> convertPath = GetPathToConvert(money.Currency, targetCurrency); //получаем путь для конвертирования
            convertPath.ForEach(item => money.Count *= (decimal)item.Rate);

            return money;
        }

        /*Когда у обеих валют - базовый курс основан не на какой то одной валюте - надо найти путь/все множители для конвертации к конечной валюте 
         Если представить эти пути в виде графа - то будет ясно, что надо как минимум пытаться идти в противоположные стороны на графе,
        тк время на задание ограничено - возможно алгоритм не идеален. Однако я рассмотрел большую часть случаев, предварительно нарисовав этот граф
        и отрывал разные рёбра на пути от from до target, и обратно - и протестировал эти сценарии */
        public List<Currency> GetPathToConvert(Currency from, Currency target, bool withoutRecursion = false)
        {
            List<Currency> pathToConvert = new();

            if (from == target)
                return pathToConvert;

            Currency selectedCurrency = from;
            do
            {
                //регистируем один из участков пути, чтобы не уйти в бесконечный цикл, в случае, когда путь невозможен
                if (pathToConvert.Contains(selectedCurrency))
                    break;

                pathToConvert.Add(selectedCurrency);
                selectedCurrency = selectedCurrency.BaseCurrency;
            }
            while (selectedCurrency != target);

            if (selectedCurrency != target && !withoutRecursion) //Путь не найден, ищем обратный
                return GetReversePath(from, target);

            return pathToConvert; //Путь найден
        }

        private List<Currency> GetReversePath(Currency from, Currency target)
        {
            var reverseList = GetPathToConvert(target, from, true); //идём в другую сторону
            reverseList.ForEach(num => num.Rate = Math.Round(1 / (decimal)num.Rate, 2)); //берём обратный курс

            return reverseList;
        }
    }
}

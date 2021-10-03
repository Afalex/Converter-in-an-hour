using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConverterTests
{
    [TestClass]
    public class ArithmeticOperationsTests : ConverterBaseTestController
    {
        [TestMethod]
        public void AdditionOperationTest()
        {
            //Arrange
            ICurrencyConverter converter = new Converter();

            var actual = converter.AddAndReturnInFirstCurrency(new Money() { Count = 500, Currency = currencies["RUB"] }, new Money() { Currency = currencies["USD"], Count = 20 });
            //курс доллара - 72.219
            //500 + 20* 72.219 = 1 944,38
            decimal expected = 1944.38M;
            Assert.IsTrue(expected == actual.Count);
        }

        [TestMethod]
        public void SubtractionOperationTest()
        {
            //Arrange
            ICurrencyConverter converter = new Converter();

            var actual = converter.SubstractAndReturnInFirstCurrency(new Money() { Currency = currencies["USD"], Count = 20 }, new Money() { Count = 500, Currency = currencies["RUB"] });

            decimal expected = Math.Truncate(20 - 6.92M);
            Assert.IsTrue(expected == Math.Truncate(actual.Count));
        }
    }
}
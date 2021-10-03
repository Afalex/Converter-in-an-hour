using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConverterTests
{

    [TestClass]
    public class CurrencyConverterTests : ConverterBaseTestController
    {

        [TestMethod]
        public void ConvertRubToCnyTest()
        {
            //Arrange
            ICurrencyConverter converter = new Converter();
            Money rub = new Money() { Count = 100, Currency = currencies["RUB"] };

            //Act
            var actual = Math.Truncate(converter.Convert(rub, currencies["CNY"]).Count);

            //Assert
            Assert.IsTrue(actual == 9);
        }

        [TestMethod]
        public void ConvertCnyToRubTest()
        {
            //Arrange
            ICurrencyConverter converter = new Converter();
            Money rub = new Money() { Count = 100, Currency = currencies["CNY"] };

            //Act
            var actual = Math.Truncate(converter.Convert(rub, currencies["RUB"]).Count);

            //Assert
            Assert.IsTrue(actual == 1083);
        }

        [TestMethod]
        public void ConvertCnyToRubTestWithReversePathInGraph()
        {
            #region пройденный путь
            /*ёань в евро
             100 * 0.13
             ≈вро в рубли 
             13 * 83.33 = 1†083,29*/
            #endregion

            //Arrange
            var cnyCurrency = currencies["CNY"];
            cnyCurrency.Rate = 0.13M;
            cnyCurrency.BaseCurrency = currencies["EUR"]; //вынуждаем алгоритм искать другой путь

            ICurrencyConverter converter = new Converter();
            Money rub = new Money() { Count = 100, Currency = currencies["CNY"] };

            //Act
            var actual = Math.Truncate(converter.Convert(rub, currencies["RUB"]).Count);

            //Assert
            Assert.IsTrue(actual == 1083);
        }

        [TestMethod]
        public void ConvertRubToRub()
        {
            //Arrange
            ICurrencyConverter converter = new Converter();
            Money rub = new Money() { Count = 100, Currency = currencies["RUB"] };

            //Act
            var actual = Math.Truncate(converter.Convert(rub, currencies["RUB"]).Count);

            //Assert
            Assert.IsTrue(actual == 100);
        }
    }
}

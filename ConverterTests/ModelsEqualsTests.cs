using CurrencyConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConverterTests
{
    [TestClass]
    public class ModelsEqualsTests : ConverterBaseTestController
    {
        [TestMethod]
        public void MoneyEqualsTest()
        {
            //Assert
            var rub = new Money() { Count = 100, Currency = currencies["RUB"] };
            var rub2 = new Money() { Count = 100, Currency = currencies["RUB"] };

            //Act, Equal
            Assert.IsTrue(rub == rub2);
        }
    }
}

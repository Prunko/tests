using ht20;
using Moq;

namespace ht20_TestProject
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_ShouldReturnBuy()
        {
            var mockExchange = new Mock<IExchangeService>();
            mockExchange.Setup(e => e.GetCurrentPrice("BTC")).Returns(85m);

            var bot = new TradingBot(mockExchange.Object);

            var result = bot.ExecuteStrategy("BTC", 100m);

            Assert.AreEqual("Buy", result);
        }

        [TestMethod]
        public void Test_ShouldReturnSell()
        {
            var mockExchange = new Mock<IExchangeService>();
            mockExchange.Setup(e => e.GetCurrentPrice("BTC")).Returns(115m);

            var bot = new TradingBot(mockExchange.Object);

            var result = bot.ExecuteStrategy("BTC", 100m);

            Assert.AreEqual("Sell", result);
        }

        [TestMethod]
        public void Test_ShouldReturnHold()
        {
            var mockExchange = new Mock<IExchangeService>();
            mockExchange.Setup(e => e.GetCurrentPrice("BTC")).Returns(96m);

            var bot = new TradingBot(mockExchange.Object);

            var result = bot.ExecuteStrategy("BTC", 100m);

            Assert.AreEqual("Hold", result);
        }
    }
}

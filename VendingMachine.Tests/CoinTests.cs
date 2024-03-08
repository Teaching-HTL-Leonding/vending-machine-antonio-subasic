using VendingMachine.Logic;

namespace VendingMachine.Tests;

public class CoinTests
{
    [Theory]
    [InlineData("2e", 200)]
    [InlineData("1e", 100)]
    [InlineData("50c", 50)]
    [InlineData("20c", 20)]
    [InlineData("10c", 10)]
    public void ParseValidCoin_ShouldReturnValue(string coin, int value)
    {
        var result = Coin.Parse(coin);
        Assert.Equal(result, value);
    }

    [Theory]
    [InlineData("3e")]
    [InlineData("1d")]
    [InlineData("50")]
    [InlineData("20Cents")]
    public void ParseInvalidCoin_ShouldThrowFormatException(string coin)
    {
        Assert.Throws<FormatException>(() => Coin.Parse(coin));
    }
}

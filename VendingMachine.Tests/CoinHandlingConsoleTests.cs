namespace VendingMachine.Tests;

public class CoinHandlingConsoleTests
{
    [Fact]
    public void OnlyValidCoinsEnteredProductPriceReachedExactly_ChangeShouldBeZero()
    {
        var chc = new CoinHandlingConsoleMock(["1.5E", "1E", "50C"]);
        chc.HandleCoins();
        Assert.Equal("change: 0E", chc.Outputs.Last());
    }

    [Fact]
    public void OnlyValidCoinsEnteredProductPriceExceeded_ChangeShouldNotBeZero()
    {
        var chc = new CoinHandlingConsoleMock(["1.5E", "1E", "2E"]);
        chc.HandleCoins();
        Assert.Equal("change: 1.5E", chc.Outputs.Last());
    }

    [Fact]
    public void InvalidCoinEntered_ShouldPrintInvalidCoin()
    {
        var chc = new CoinHandlingConsoleMock(["1.5E", "3E", "1E", "50C"]);
        chc.HandleCoins();
        Assert.Equal("invalid coin", chc.Outputs[2]);
    }
}
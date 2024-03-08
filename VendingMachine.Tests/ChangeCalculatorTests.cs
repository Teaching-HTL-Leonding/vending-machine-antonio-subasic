using VendingMachine.Logic;

namespace VendingMachine.Tests;

public class ChangeCalculatorTests
{
    [Fact]
    public void InitializeChangeCalculator_TotalAmountShouldBeZero()
    {
        var cc = new ChangeCalculator(100);
        Assert.Equal(0, cc.TotalAmount);
    }

    [Fact]
    public void AddCoins_ShouldUpdateTotalAmount()
    {
        var cc = new ChangeCalculator(100);
        
        cc.AddCoin(50);
        Assert.Equal(50, cc.TotalAmount);
        
        cc.AddCoin(50);
        Assert.Equal(100, cc.TotalAmount);
    }

    [Fact]
    public void AddCoinsAboveIntMaxValue_ShouldThrowOverflowException()
    {
        var cc = new ChangeCalculator(100);
        cc.AddCoin(int.MaxValue);
        Assert.Throws<OverflowException>(() => cc.AddCoin(1));
    }

    [Fact]
    public void TotalAmountEqualOrGreaterThanPrice_IsEnoughMoneyShouldReturnTrue()
    {
        var cc = new ChangeCalculator(100);
        cc.AddCoin(100);
        Assert.True(cc.IsEnoughMoney);
    }

    [Fact]
    public void TotalAmountLessThanPrice_IsEnoughMoneyShouldReturnFalse()
    {
        var cc = new ChangeCalculator(100);
        cc.AddCoin(50);
        Assert.False(cc.IsEnoughMoney);
    }

    [Fact]
    public void GetChangeSucceeds_ShouldReturnCorrectChange()
    {
        var cc = new ChangeCalculator(100);

        cc.AddCoin(100);
        var change = cc.GetChange();
        Assert.Equal(0, change);
        Assert.Equal(0, cc.TotalAmount);

        cc.AddCoin(250);
        change = cc.GetChange();
        Assert.Equal(150, change);
        Assert.Equal(0, cc.TotalAmount);
    }

    [Fact]
    public void GetChangeFails_ShouldThrowInvalidOperationException()
    {
        var cc = new ChangeCalculator(100);
        Assert.Throws<InvalidOperationException>(() => cc.GetChange());
    }
}

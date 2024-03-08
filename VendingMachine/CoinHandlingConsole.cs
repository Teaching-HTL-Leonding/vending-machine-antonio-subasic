namespace VendingMachine.Logic;

public class CoinHandlingConsole
{
    public virtual void WriteLine(string? s = null) => Console.WriteLine(s);

    public virtual string ReadLine() => Console.ReadLine()!;

    public int HandleCoins()
    {
        WriteLine("enter the price:");

        var cc = new ChangeCalculator(Coin.ParseAny(ReadLine()));

        while (!cc.IsEnoughMoney)
        {
            try
            {
                WriteLine("throw in a coin:");
                cc.AddCoin(Coin.Parse(ReadLine()));
                WriteLine($"total amount: {Coin.FormatPrice(cc.TotalAmount)}");
            }
            catch (Exception ex) when (ex is FormatException or OverflowException)
            {
                WriteLine("invalid coin");
            }
        }

        var change = cc.GetChange();
        WriteLine($"change: {Coin.FormatPrice(change)}");
        return change;
    }
}

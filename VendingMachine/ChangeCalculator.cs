namespace VendingMachine.Logic;

public class ChangeCalculator(int price)
{
    public int Price => price;
    public int TotalAmount { get; private set; }
    public bool IsEnoughMoney => TotalAmount >= Price;

    public int AddCoin(int value) => checked(TotalAmount += value);

    public int GetChange()
    {
        if (!IsEnoughMoney) { throw new InvalidOperationException("not enough money"); }
        else
        {
            var change = TotalAmount - Price;
            TotalAmount = 0;
            return change;
        }
    }
}

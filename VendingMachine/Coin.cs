namespace VendingMachine.Logic;

public static class Coin
{
    public static int Parse(string coin)
    {
        return coin.ToLower() switch
        {
            "2e" => 200,
            "1e" => 100,
            "50c" => 50,
            "20c" => 20,
            "10c" => 10,
            _ => throw new FormatException("invalid coin")
        };
    }

    public static int ParseAny(string coin)
        => char.ToLower(coin[^1]) == 'e' ? (int)(decimal.Parse(coin[..^1]) * 100) : int.Parse(coin[..^1]);

    public static string FormatPrice(int price)
    {
        var euroPrice = price / 100m;
        return euroPrice < 0 ? $"{price}C" : $"{euroPrice}E";
    }
}

using VendingMachine.Logic;

namespace VendingMachine.Tests;

public class CoinHandlingConsoleMock(string[] inputs) : CoinHandlingConsole
{
    public List<string?> Outputs { get; } = [];
    private int _numberOfReadLineCommands { get; set; }

    public override void WriteLine(string? s) => Outputs.Add(s);
    public override string ReadLine() => inputs[_numberOfReadLineCommands++];
}

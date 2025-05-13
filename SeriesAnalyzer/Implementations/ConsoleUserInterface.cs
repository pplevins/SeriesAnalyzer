using SeriesAnalyzer.Interfaces;

namespace SeriesAnalyzer.Implementations;

/// <summary>
/// A simple implementation for the user interface using a simple Console commands.
/// </summary>
internal class ConsoleUserInterface : IUserInterface
{
    /// <inheritdoc/>
    public string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "";
    }

    /// <inheritdoc/>
    public void ShowOutput(string message)
    {
        Console.WriteLine(message);
    }
}

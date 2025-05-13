namespace SeriesAnalyzer.Implementations;

using SeriesAnalyzer.Interfaces;
internal class ConsoleUserInterface : IUserInterface
{
    public string GetInput(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine() ?? "";
    }

    public void ShowOutput(string message)
    {
        Console.WriteLine(message);
    }
}

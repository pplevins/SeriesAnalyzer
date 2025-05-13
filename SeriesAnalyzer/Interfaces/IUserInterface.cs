namespace SeriesAnalyzer.Interfaces;

internal interface IUserInterface
{
    string GetInput(string prompt);
    void ShowOutput(string message);
}

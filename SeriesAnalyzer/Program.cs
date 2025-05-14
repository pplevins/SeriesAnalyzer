using SeriesAnalyzer.Implementations;
using SeriesAnalyzer.Menu;
using SeriesAnalyzer.Services;

namespace SeriesAnalyzer;

/// <summary>
/// Endpoint program class for the series analyzer project.
/// </summary>
internal class Program
{
    /// <summary>
    /// Main of the program
    /// </summary>
    /// <param name="args">Arguments supplied by the user in runtime.</param>
    static void Main(string[] args)
    {
        var ui = new ConsoleUserInterface();
        var service = new NumberSeriesService();

        try
        {
            int[] initialNumbers = args.Length > 0
                ? service.ParseSeries(string.Join(' ', args))
                : [];

            var menu = new SeriesMenu(ui, service, initialNumbers);
            ui.ShowOutput("Welcome to the Series Analyzer!");
            menu.Run();
        }
        catch (Exception ex)
        {
            ui.ShowOutput($"Error: {ex.Message}");
        }
    }
}

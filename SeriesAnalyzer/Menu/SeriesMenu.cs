using SeriesAnalyzer.Interfaces;
using SeriesAnalyzer.Services;

namespace SeriesAnalyzer.Menu;

/// <summary>
/// Supplies the menu of options for the numbers series represented to the user.
/// </summary>
internal class SeriesMenu
{
    private int[] _numbers;
    private readonly IUserInterface _ui;
    private readonly NumberSeriesService _service;

    /// <summary>
    /// Constructing the series menu used in the program.
    /// </summary>
    /// <param name="ui">The user interface for I/O.</param>
    /// <param name="service">The services class for the options.</param>
    /// <param name="initialNumbers">The initail series of numbers.</param>
    public SeriesMenu(IUserInterface ui, NumberSeriesService service, int[] initialNumbers)
    {
        _ui = ui;
        _service = service;
        _numbers = initialNumbers;
    }

    /// <summary>
    /// Runs the menu and presenting the services to the user.
    /// </summary>
    public void Run()
    {
        string choice;
        do
        {
            DisplayMenu();
            choice = _ui.GetInput("Choose your option:").ToLower();

            switch (choice)
            {
                case "a":
                    var input = _ui.GetInput("Enter series of numbers (e.g.: 1 2 3):");
                    _numbers = _service.ParseSeries(input);
                    _ui.ShowOutput("Series updated successfully!");
                    break;
                case "b":
                    ShowSeries("Series in original order:", _numbers);
                    break;
                case "c":
                    ShowSeries("Series in reverse order:", _service.Reverse(_numbers));
                    break;
                case "d":
                    ShowSeries("Sorted series:", _service.Sort(_numbers));
                    break;
                case "e":
                    _ui.ShowOutput($"Max value: {_service.GetMax(_numbers)}");
                    break;
                case "f":
                    _ui.ShowOutput($"Min value: {_service.GetMin(_numbers)}");
                    break;
                case "g":
                    _ui.ShowOutput($"Average: {_service.GetAverage(_numbers):F2}");
                    break;
                case "h":
                    _ui.ShowOutput($"Number of elements: {_numbers.Length}");
                    break;
                case "i":
                    _ui.ShowOutput($"Sum of the series: {_service.GetSum(_numbers)}");
                    break;
                case "j":
                    _ui.ShowOutput("Exiting program...");
                    break;
                default:
                    _ui.ShowOutput("Invalid option. Please enter a letter between a-j.");
                    break;
            }
        } while (choice != "j");
    }

    /// <summary>
    /// Showing the series to the user.
    /// </summary>
    /// <param name="title">Title for the series printing.</param>
    /// <param name="series">The number series.</param>
    private void ShowSeries(string title, int[] series)
    {
        string output = $"{title}\n{string.Join(" ", series)}\n";
        _ui.ShowOutput(output);
    }

    /// <summary>
    /// Displaing the menu of options.
    /// </summary>
    private void DisplayMenu()
    {
        _ui.ShowOutput(@"Menu:
    a. Input a new series
    b. Display original series
    c. Display reversed series
    d. Display sorted series
    e. Display max value
    f. Display min value
    g. Display average
    h. Display number of elements
    i. Display sum
    j. Exit");
    }
}

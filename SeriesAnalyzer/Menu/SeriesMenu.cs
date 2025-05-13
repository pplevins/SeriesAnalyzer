using SeriesAnalyzer.Interfaces;
using SeriesAnalyzer.Services;

namespace SeriesAnalyzer.Menu;

internal class SeriesMenu
{
    private int[] _numbers;
    private readonly IUserInterface _ui;
    private readonly NumberSeriesService _service;

    public SeriesMenu(IUserInterface ui, NumberSeriesService service, int[] initialNumbers)
    {
        _ui = ui;
        _service = service;
        _numbers = initialNumbers;
    }

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

    private void ShowSeries(string title, int[] series)
    {
        string output = $"{title}\n{string.Join(" ", series)}\n";
        _ui.ShowOutput(output);
    }

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

namespace SeriesAnalyzer;

internal class Program
{
    /// <summary>
    /// Setting the number series from user
    /// </summary>
    /// <param name="args">the arguments array from CMD</param>
    /// <returns>Array of number series.</returns>
    static int[] SetNumberSeries(string[] args)
    {
        if (args.Length == 0)
            return EvaluateNumbers(GetSeriesFromUser());
        else
            return EvaluateNumbers(args);
    }

    /// <summary>
    /// Parsing the input to a integer.
    /// </summary>
    /// <param name="input">the input string to parse.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">In case it wasn't a positive integer.</exception>
    static int ParseToInt(string input)
    {
        return int.TryParse(input, out var result) && result >= 0 ? result 
            : throw new ArgumentException("Error! input must be a positive number.");
    }

    /// <summary>
    /// Asking the user to enter the numbers series.
    /// </summary>
    /// <returns>The string odf numbers from the user</returns>
    /// <exception cref="ArgumentNullException">In case nothing was entered.</exception>
    static string[] GetSeriesFromUser()
    {
        Console.WriteLine("Enter series of numbers (e.g.: 1 2 3)");
        string? input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
            throw new ArgumentNullException("Error, you didn't enter any numbers!");
        return input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Evaluating the string from the user to array of numbers.
    /// </summary>
    /// <param name="input">The input string from the user.</param>
    /// <returns>The array of the numbers.</returns>
    /// <exception cref="ArgumentException">In case the input is less than 3 numbers.</exception>
    static int[] EvaluateNumbers(string[] input)
    {
        if (input.Length < 3)
            throw new ArgumentException("Error! You must enter at least 3 positive numbers");
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
            numbers[i] = ParseToInt(input[i]);
        Console.WriteLine("Series entered succesfully!");
        return numbers;
    }

    /// <summary>
    /// Displaying the number series to the user. 
    /// </summary>
    /// <param name="numbers">The numbers array.</param>
    /// <param name="massage">Massage to present to the user.</param>
    static void DisplaySeries(int[] numbers, string massage)
    {
        Console.WriteLine(massage);
        foreach (var number in numbers)
            Console.Write($"{number} ");
        Console.WriteLine("\n");
    }

    /// <summary>
    /// A simple insertion sort on the numbers array.
    /// </summary>
    /// <param name="arr">The numbers array.</param>
    /// <returns>The sorted array.</returns>
    static int[] InsertionSort(int[] arr)
    {
        int[] sorted = [.. arr];
        for (int i = 1; i < sorted.Length; i++)
        {
            int key = sorted[i];
            int j = i - 1;
            while (j >= 0 && sorted[j] > key)
            {
                sorted[j + 1] = sorted[j];
                j--;
            }
            sorted[j + 1] = key;
        }
        return sorted;
    }

    /// <summary>
    /// Implementation of Array.sum()
    /// </summary>
    /// <param name="arr">Array of numbers.</param>
    /// <returns>The sum of the array.</returns>
    static int GetSumArray(int[] arr)
    {
        int sum = 0;
        foreach (int num in arr)
            sum += num;
        return sum;
    }

    /// <summary>
    /// Displaying the menu of options to the user.
    /// </summary>
    static void DisplayMenu()
    {
        Console.WriteLine(@"Choose your option (a-j):
    a. Input a Series. (Replace the current series)
    b. Display the series in the order it was entered.
    c. Display the series in the reversed order it was entered.
    d. Display the series in sorted order (from low to high).
    e. Display the Max value of the series.
    f. Display the Min value of the series.
    g. Display the Average of the series.
    h. Display the Number of elements in the series.
    i. Display the Sum of the series.
    j. Exit.");
    }

    /// <summary>
    /// Operates function on the number series according to user's choice.
    /// </summary>
    /// <param name="numberSeries">The series of numbers.</param>
    static void MenuManager(int[] numberSeries)
    {
        string choice;
        do
        {
            DisplayMenu();
            choice = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(choice))
            {
                switch (choice)
                {
                    case "a":
                    case "A":
                        numberSeries = EvaluateNumbers(GetSeriesFromUser());
                        break;
                    case "b":
                    case "B":
                        DisplaySeries(numberSeries, "The series in the original order:");
                        break;
                    case "c":
                    case "C":
                        DisplaySeries([.. numberSeries.Select(
                                (value, index) => numberSeries[numberSeries.Length - 1 - index])],
                            "The series in the reverse order it was entered:");
                        break;
                    case "d":
                    case "D":
                        DisplaySeries(InsertionSort(numberSeries), "The sorted series:");
                        break;
                    case "e":
                    case "E":
                        Console.WriteLine($"The max value in the array is: " +
                            numberSeries.Aggregate((a, b) => a > b ? a : b));
                        break;
                    case "f":
                    case "F":
                        Console.WriteLine($"The min value in the array is: " +
                            numberSeries.Aggregate((a, b) => a < b ? a : b));
                        break;
                    case "g":
                    case "G":
                        Console.WriteLine("The Avarage of the series is: " +
                            $"{((double)GetSumArray(numberSeries) / numberSeries.Length):F2}");
                        break;
                    case "h":
                    case "H":
                        Console.WriteLine("The number of elements in the series is: " +
                            numberSeries.Length);
                        break;
                    case "i":
                    case "I":
                        Console.WriteLine("The sum of the series is: " +
                            GetSumArray(numberSeries));
                        break;
                    case "j":
                    case "J":
                        break;
                    default:
                        Console.WriteLine("It has to be a letter between (a-j)");
                        break;
                }
            }
            else
                Console.WriteLine("You must enter somthing");
        }
        while (choice != "j" && choice != "J");
    }

    /// <summary>
    /// Menu for the program
    /// </summary>
    /// <param name="args">Arguments supplied by the user in runtime.</param>
    static void Main(string[] args)
    {
        int[] numberSeries;
        Console.WriteLine("Welcome to the Series Analyzer Program!\n");
        try
        {
            numberSeries = SetNumberSeries(args);
            MenuManager(numberSeries);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

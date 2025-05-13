namespace SeriesAnalyzer.Services;

/// <summary>
/// Supplies the analyzing services for the numbers series.
/// </summary>
internal class NumberSeriesService
{
    /// <summary>
    /// Parsing the input string to a array of numbers.
    /// </summary>
    /// <param name="input">The input string from the user.</param>
    /// <returns>Array of numbers.</returns>
    /// <exception cref="ArgumentException">In case of an empty string, or less than 3 positive numbers.</exception>
    public int[] ParseSeries(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("You didn't enter any numbers!");

        string[] parts = input.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3)
            throw new ArgumentException("You must enter at least 3 positive numbers");

        int[] numbers = [.. parts.Select(ParseToInt)];
        return numbers;
    }

    /// <summary>
    /// Parsing a string to a integer.
    /// </summary>
    /// <param name="input">The input string from the user.</param>
    /// <returns>A positive integer.</returns>
    /// <exception cref="ArgumentException">In case of non positive number in the string.</exception>
    private int ParseToInt(string input)
    {
        return int.TryParse(input, out var result) && result >= 0
            ? result
            : throw new ArgumentException("Input must be a positive number.");
    }

    /// <summary>
    /// Sorting the numbers series using OrderBy.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The sorted numbers.</returns>
    public int[] Sort(int[] numbers) =>
        [.. numbers.OrderBy(n => n)];

    /// <summary>
    /// Sorting the numbers series to a reverse order.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The sorted numbers.</returns>
    public int[] Reverse(int[] numbers) =>
        [.. numbers.Reverse()];

    /// <summary>
    /// Getting the max value of the series.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The max value.</returns>
    public int GetMax(int[] numbers) =>
        numbers.Max();

    /// <summary>
    /// Getting the min value of the series.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The min value.</returns>
    public int GetMin(int[] numbers) =>
        numbers.Min();

    /// <summary>
    /// Getting the avarage of the series.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The avarage of the series.</returns>
    public double GetAverage(int[] numbers) =>
        numbers.Average();

    /// <summary>
    /// Getting the sum of the series.
    /// </summary>
    /// <param name="numbers">The numbers series.</param>
    /// <returns>The sum of the series.</returns>
    public int GetSum(int[] numbers) =>
        numbers.Sum();
}

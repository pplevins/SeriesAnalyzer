namespace SeriesAnalyzer.Services;

internal class NumberSeriesService
{
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

    private int ParseToInt(string input)
    {
        return int.TryParse(input, out var result) && result >= 0
            ? result
            : throw new ArgumentException("Input must be a positive number.");
    }

    public int[] Sort(int[] numbers) =>
        [.. numbers.OrderBy(n => n)];

    public int[] Reverse(int[] numbers) =>
        [.. numbers.Reverse()];

    public int GetMax(int[] numbers) =>
        numbers.Max();

    public int GetMin(int[] numbers) =>
        numbers.Min();

    public double GetAverage(int[] numbers) =>
        numbers.Average();

    public int GetSum(int[] numbers) =>
        numbers.Sum();
}

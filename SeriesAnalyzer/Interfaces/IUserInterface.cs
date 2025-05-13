namespace SeriesAnalyzer.Interfaces;

/// <summary>
/// Interface for the user interface actions needed for the program.
/// </summary>
internal interface IUserInterface
{
    /// <summary>
    /// Getting the user input to the program.
    /// </summary>
    /// <param name="prompt">The explaination prompt showing to the user.</param>
    /// <returns>The user input string.</returns>
    string GetInput(string prompt);

    /// <summary>
    /// Showing some output to the user.
    /// </summary>
    /// <param name="message">The output message for the user.</param>
    void ShowOutput(string message);
}

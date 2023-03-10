namespace Sinistrius.NumeriRomani.Exceptions;


/// <summary>
/// The exception that is thrown when a Roman number has an invalid format and cannot be interpreted.
/// </summary>
public class InvalidRomanNumberException : Exception
{

    /// <summary>
    /// Initializes the <see cref="InvalidRomanNumberException"/>.
    /// </summary>
    /// <param name="romanNumber">The invalid Roman number.</param>
    public InvalidRomanNumberException(string romanNumber) : base($"The string \"{romanNumber}\" cannot be interpreted as a valid Roman number.")
    { }

}

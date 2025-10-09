namespace LinkeEngineering.NumeriRomani.Exceptions;


/// <summary>
/// The exception that is thrown when a Roman number has an invalid format and cannot be interpreted.
/// </summary>
/// <param name="romanNumber">The invalid Roman number.</param>
public class InvalidRomanNumberException(string romanNumber) : Exception($"String \"{romanNumber}\" cannot be interpreted as a valid Roman number")
{ }

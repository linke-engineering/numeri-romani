namespace LinkeEngineering.NumeriRomani.Exceptions;


/// <summary>
/// The exception that is thrown when an invalid Roman numeral string is encountered.
/// </summary>
/// <param name="roman">The invalid Roman numeral.</param>
public class InvalidRomanNumeralException(string roman) : Exception($"Invalid Roman numeral \"{roman}\"")
{ }

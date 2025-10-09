namespace LinkeEngineering.NumeriRomani.Exceptions;


/// <summary>
/// The exception that is thrown when an invalid Roman numeral string is encountered.
/// </summary>
/// <param name="romanNumeral">The invalid Roman numeral.</param>
public class InvalidRomanNumeralException(string romanNumeral) : Exception($"Invalid Roman numeral \"{romanNumeral}\"")
{ }

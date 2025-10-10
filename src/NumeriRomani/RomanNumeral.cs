using LinkeEngineering.NumeriRomani.Exceptions;
using System.Text.RegularExpressions;


namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// A numeric value that is represented in Roman numerals.
/// </summary>
internal partial class RomanNumeral
{

    #region Local Fields

    /// <summary>
    /// A regex object that represents a valid Roman numeral.
    /// </summary>
    [GeneratedRegex(@"^ↈ{0,4}ↇ?ↂ{0,4}ↁ?M{0,4}((C[MD])|(D?C{0,4}))?((X[CL])|(L?X{0,4}))?((I[XV])|(V?I{0,4}))?$")]
    private static partial Regex RomanNumeralRegex();


    /// <summary>
    /// Represents the smallest possible value of a <see cref="RomanNumeral"/>.
    /// </summary>
    private const int MinValue = 0;


    /// <summary>
    /// Represents the largest possible value of a <see cref="RomanNumeral"/>.
    /// </summary>
    private const int MaxValue = 499999;


    /// <summary>
    /// A mapper for Roman numerals.
    /// </summary>
    private readonly RomanNumeralsMapper _mapper = new();


    /// <summary>
    /// The actual value of the <see cref="RomanNumeral"/>.
    /// </summary>
    private readonly int _value;


    /// <summary>
    /// The value written in Roman numerals.
    /// </summary>
    private readonly string _roman;

    #endregion


    #region Constructors

    /// <summary>
    /// Initializes the <see cref="RomanNumeral"/>.
    /// </summary>
    /// <param name="value">An integer that represents the value.</param>
    internal RomanNumeral(int value)
    {
        if (value < MinValue || value > MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Only integers between {MinValue} and {MaxValue} are supported.");
        }

        _value = value;
        _roman = _mapper.ConvertIntegerToRoman(value);
    }


    /// <summary>
    /// Initializes the <see cref="RomanNumeral"/>.
    /// </summary>
    /// <param name="roman">A string that represents the value written in Roman numerals.</param>
    internal RomanNumeral(string? roman)
    {
        ArgumentNullException.ThrowIfNull(roman, nameof(roman));

        if (!RomanNumeralRegex().IsMatch(roman))
        {
            throw new InvalidRomanNumeralException(roman.ToString());
        }

        _roman = roman;
        _value = _mapper.ConvertRomanToInteger(roman);
    }

    #endregion


    #region Properties

    /// <summary>
    /// The numeric value of the <see cref="RomanNumeral"/>.
    /// </summary>
    internal int IntValue => _value;

    #endregion


    #region Methods

    /// <summary>
    /// Gets the value of the <see cref="RomanNumeral"/> written in Roman numerals.
    /// </summary>
    /// <returns>A string that represents the value written in Roman numerals.</returns>
    public override string ToString() => _roman;

    #endregion

}

using Sinistrius.NumeriRomani.Exceptions;
using System.Text.RegularExpressions;


namespace Sinistrius.NumeriRomani;


/// <summary>
/// A number that is represented in Roman numerals.
/// </summary>
internal class RomanNumber
{

    #region Local Fields

    /// <summary>
    /// The regex pattern of a valid Roman number.
    /// </summary>
    private const string RomanNumberPattern = @"^ↈ{0,4}ↇ?ↂ{0,4}ↁ?M{0,4}((C[MD])|(D?C{0,4}))?((X[CL])|(L?X{0,4}))?((I[XV])|(V?I{0,4}))?$";


    /// <summary>
    /// Represents the smallest possible value of a <see cref="RomanNumber"/>.
    /// </summary>
    private const int MinValue = 0;


    /// <summary>
    /// Represents the largest possible value of a <see cref="RomanNumber"/>.
    /// </summary>
    private const int MaxValue = 499999;


    /// <summary>
    /// A mapper for Roman numerals.
    /// </summary>
    private readonly RomanNumeralMapper _mapper = new();


    /// <summary>
    /// The actual value of the <see cref="RomanNumber"/>.
    /// </summary>
    private readonly int _value;


    /// <summary>
    /// The <see cref="RomanNumber"/> written in Roman numerals.
    /// </summary>
    private readonly string _romanNumber;

    #endregion


    #region Constructors

    /// <summary>
    /// Initializes the <see cref="RomanNumber"/>.
    /// </summary>
    /// <param name="number">An integer that represents the value.</param>
    internal RomanNumber(int number)
    {
        if (number < MinValue || number > MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(number), $"Currently only integers between {MinValue} and {MaxValue} are supported.");
        }

        _value = number;
        _romanNumber = _mapper.ConvertIntegerToRoman(number);
    }


    /// <summary>
    /// Initializes the <see cref="RomanNumber"/>.
    /// </summary>
    /// <param name="romanNumber">A string that represents the value written in Roman numerals.</param>
    internal RomanNumber(string? romanNumber)
    {
        if (romanNumber == null)
        {
            throw new ArgumentNullException(nameof(romanNumber));
        }

        if (!Regex.IsMatch(romanNumber, RomanNumberPattern))
        {
            throw new InvalidRomanNumberException(romanNumber.ToString());
        }

        _romanNumber = romanNumber;
        _value = _mapper.ConvertRomanToInteger(romanNumber);
    }

    #endregion


    #region Properties

    /// <summary>
    /// The actual value of the <see cref="RomanNumber"/>.
    /// </summary>
    internal int Value => _value;

    #endregion


    #region Methods

    /// <summary>
    /// Gets the value of the <see cref="RomanNumber"/> in Roman numerals.
    /// </summary>
    /// <returns>A string that represents the value written in Roman numerals.</returns>
    public override string ToString() => _romanNumber;

    #endregion

}

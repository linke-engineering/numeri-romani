using System.Globalization;
using System.Text;

namespace Sinistrius.NumeriRomani;


/// <summary>
/// A formatter to format numbers as Roman numerals.
/// </summary>
public class RomanNumeralsFormatter : IFormatProvider, ICustomFormatter
{

    #region Constants

    /// <summary>
    /// The format string to indicate formatting as Roman numeral.
    /// </summary>
    private const string RomanFormatString = "R";

    #endregion


    #region Implementation of IFormatProvider

    /// <inheritdoc/>
    public object? GetFormat(Type? formatType)
    {
        if (formatType == typeof(ICustomFormatter))
        {
            return this;
        }
        else
        {
            return null;
        }
    }

    #endregion


    #region Implementation of ICustomFormatter

    /// <inheritdoc/>
    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        // Validate format provider
        if (!Equals(formatProvider))
        {
            return null;
        }

        // Set default format string
        if (String.IsNullOrEmpty(format))
        {
            format = RomanFormatString;
        }

        // Validate format string
        if (format != RomanFormatString)
        {
            throw new FormatException(String.Format("'{0}' cannot be used to format {1}.", format, arg.ToString()));
        }

        // Skip empty value
        if (String.IsNullOrEmpty(arg.ToString()) || arg.ToString() == "0")
        {
            return "";
        }

        // Reject values that aren't non-negative integers
        if (!Int32.TryParse(arg.ToString(), out int number) || number < 0)
        {
            throw new ArgumentException($"{arg} is not a non-negative integer.", nameof(arg));
        }

        // Convert to Roman numeral
        StringBuilder stringBuilder = new();

        foreach (KeyValuePair<int, string> numeral in new RomanNumeralsDictionary())
        {
            if (number <= 0)
            {
                break;
            }

            while (number >= numeral.Key)
            {
                stringBuilder.Append(numeral.Value);
                number -= numeral.Key;
            }
        }

        return stringBuilder.ToString();
    }

    #endregion

}
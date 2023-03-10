namespace Sinistrius.NumeriRomani;


/// <summary>
/// A formatter to format numbers as Roman numerals.
/// </summary>
public class RomanNumeralsFormatter : IFormatProvider, ICustomFormatter
{

    #region Local Field

    /// <summary>
    /// A list of allowed format strings.
    /// </summary>
    private readonly List<string?> _validFormatStrings = new() { null, "", "g", "G", "R" };

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

        // Skip empty value
        if (arg == null || String.IsNullOrEmpty(arg.ToString()) || arg.ToString() == "0")
        {
            return "";
        }

        // Validate format string
        if (!_validFormatStrings.Contains(format))
        {
            throw new FormatException(String.Format("'{0}' cannot be used to format {1}.", format, arg.ToString()));
        }

        // Reject values that aren't non-negative integers
        if (!Int32.TryParse(arg.ToString(), out int number))
        {
            throw new ArgumentException($"{arg} is not an integer.", nameof(arg));
        }

        // Convert to Roman representation
        RomanNumber romanNumber = new(number);
        return romanNumber.ToString();
    }

    #endregion

}
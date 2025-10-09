namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// A formatter to format numbers as Roman numerals.
/// </summary>
public class RomanNumeralsFormatter : IFormatProvider, ICustomFormatter
{

    #region Local Fields

    /// <summary>
    /// A list of allowed format strings.
    /// </summary>
    private static readonly HashSet<string?> _validFormatStrings = new() { null, "", "g", "G", "R" };

    #endregion


    #region Methods

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


    /// <inheritdoc/>
    public string Format(string? format, object? arg, IFormatProvider? formatProvider)
    {
        string? argString = arg?.ToString();

        // Skip empty value
        if (String.IsNullOrEmpty(argString) || argString == "0")
        {
            return "";
        }

        // Validate format string
        if (!_validFormatStrings.Contains(format))
        {
            throw new FormatException(String.Format("'{0}' cannot be used to format {1}.", format, argString));
        }

        // Reject values that aren't non-negative integers
        if (!Int32.TryParse(argString, out int number))
        {
            throw new ArgumentException($"{arg} is not an integer.", nameof(arg));
        }

        // Convert to Roman representation
        RomanNumber romanNumber = new(number);
        return romanNumber.ToString();
    }

    #endregion

}
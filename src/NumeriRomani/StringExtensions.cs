namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// Extends the <see cref="string"/> class.
/// </summary>
public static class StringExtensions
{

    /// <summary>
    /// Converts the Roman numeral representation of a value to its integer equivalent.
    /// </summary>
    /// <param name="s">A string that represents the value written in Roman numerals.</param>
    /// <returns>An integer that represents the conversion result.</returns>
    public static int ParseRoman(this string s)
    {
        RomanNumber romanNumber = new(s);
        return romanNumber.Value;
    }


    /// <summary>
    /// Converts the Roman numeral representation of a value to its integer equivalent.
    /// </summary>
    /// <param name="s">A string that represents the value written in Roman numerals.</param>
    /// <param name="value">An integer that takes the conversion result.</param>
    /// <returns>True if the value was converted successfully, otherwise false.</returns>
    public static bool TryParseRoman(this string s, out int value)
    {
        try
        {
            value = s.ParseRoman();
            return true;
        }
        catch
        {
            value = 0;
            return false;
        }
    }

}

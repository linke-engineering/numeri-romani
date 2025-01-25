namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// Extends the <see cref="Int32"/> struct.
/// </summary>
public static class Int32Extension
{

    #region Methods

    /// <summary>
    /// Shortcut extension to format an integer value as a Roman numeral.
    /// </summary>
    /// <param name="value">An integer that represents the value to be formatted.</param>
    /// <returns>The value as Roman numeral.</returns>
    public static string ToRoman(this int value)
    {
        RomanNumber romanNumber = new(value);
        return romanNumber.ToString();
    }


    /// <summary>
    /// Converts the Roman numeral representation of a value to its integer equivalent.
    /// </summary>
    /// <param name="s">A string that represents the value written in Roman numerals.</param>
    /// <param name="value">An integer that takes the conversion result.</param>
    /// <returns>An integer that represents the conversion result.</returns>
    public static int ParseRoman(string? s)
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
    public static bool TryParseRoman(string? s, out int value)
    {
        try
        {
            value = ParseRoman(s);
            return true;
        }
        catch
        {
            value = 0;
            return false;
        }
    }

    #endregion

}

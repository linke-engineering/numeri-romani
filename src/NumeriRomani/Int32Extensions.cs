namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// Provides extension methods for the <see cref="Int32"/> struct.
/// </summary>
public static class Int32Extensions
{

    /// <summary>
    /// Shortcut extension to format an integer value as a Roman numeral.
    /// </summary>
    /// <param name="value">An integer that represents the value to be formatted.</param>
    /// <returns>The value as Roman numeral.</returns>
    public static string ToRoman(this int value)
    {
        RomanNumeral roman = new(value);
        return roman.ToString();
    }

}

namespace Sinistrius.NumeriRomani;


/// <summary>
/// A dictionary that contains integers and their Roman equivalent.
/// </summary>
internal class RomanNumeralsDictionary : Dictionary<int, string>
{

    /// <summary>
    /// Initializes the <see cref="RomanNumeralsDictionary"/>.
    /// </summary>
    internal RomanNumeralsDictionary()
    {
        Add(100000, "ↈ");
        Add(50000, "ↇ");
        Add(10000, "ↂ");
        Add(5000, "ↁ");
        Add(1000, "M");
        Add(900, "CM");
        Add(500, "D");
        Add(400, "CD");
        Add(100, "C");
        Add(90, "XC");
        Add(50, "L");
        Add(40, "XL");
        Add(10, "X");
        Add(9, "IX");
        Add(5, "V");
        Add(4, "IV");
        Add(1, "I");
    }

}

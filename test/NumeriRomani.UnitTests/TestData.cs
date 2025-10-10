namespace LinkeEngineering.NumeriRomani.UnitTests;


/// <summary>
/// Provides test data for the UnitTests class.
/// </summary>
/// <remarks>
/// The return types are used by the <see cref="DynamicDataAttribute"/> and therefore have to be tuples or object arrays.
/// </remarks>
internal class TestData
{

    /// <summary>
    /// A collection of valid Roman numerals and their integer representation.
    /// </summary>
    /// <returns>A collection of tuples containing Roman numeral strings and their corresponding integer values.</returns>
    internal static IEnumerable<(string Roman, int Value)> RomansAndInts()
    {
        yield return ("", 0);
        yield return ("I", 1);
        yield return ("II", 2);
        yield return ("XLIX", 49);
        yield return ("MMXXIII", 2023 );
        yield return ("ↈↈↈↈↇↂↂↂↂↁMMMMCMXCIX", 499999);
    }


    /// <summary>
    /// A collection of valid integers and their Roman representation.
    /// </summary>
    /// <returns>A collection of tuples containing integers and their corresponding Roman numeral strings.</returns>
    internal static IEnumerable<(int Value, string Roman)> IntsAndRomans()
    {
        foreach (var (roman, value) in RomansAndInts())
        {
            yield return (value, roman);
        }
    }


    /// <summary>
    /// A collection of strings that are not valid as Roman numerals.
    /// </summary>
    /// <returns>A collection of tuples containing invalid Roman numeral strings.</returns>
    internal static IEnumerable<Tuple<string>> InvalidRomans()
    {
        yield return new Tuple<string> ("abc");
        yield return new Tuple<string> ("ID");
        yield return new Tuple<string> ("CCCCC");
        yield return new Tuple<string> ("MXDC");
        yield return new Tuple<string> ("ↈↈↈↈↈ");
    }


    /// <summary>
    /// A collection of integers which can not be written as Roman numerals.
    /// </summary>
    /// <returns>A collection of tuples containing invalid integers.</returns>
    internal static IEnumerable<Tuple<int>> InvalidInts()
    {
        yield return new Tuple<int> (-1);
        yield return new Tuple<int> (500000);
    }


    /// <summary>
    /// A collection of values which are not integers.
    /// </summary>
    /// <returns>A collection of tuples containing non-integer values.</returns>
    internal static IEnumerable<Tuple<object>> NonInts()
    {
        yield return new Tuple<object> ( "abc" );
        yield return new Tuple<object> ( 1.23 );
    }


    /// <summary>
    /// A collection of valid format strings to format values as Roman numerals.
    /// </summary>
    /// <returns>A collection of tuples containing valid format strings.</returns>
    internal static IEnumerable<Tuple<string>> Formats()
    {
        yield return new Tuple<string> ("{0}");
        yield return new Tuple<string> ("{0:g}");
        yield return new Tuple<string> ("{0:G}");
        yield return new Tuple<string> ("{0:R}");
    }


    /// <summary>
    /// A collection of invalid format strings to format values as Roman numerals.
    /// </summary>
    /// <returns>A collection of tuples containing invalid format strings.</returns>
    internal static IEnumerable<Tuple<string>> InvalidFormats()
    {
        yield return new Tuple<string> ("{1}");
        yield return new Tuple<string> ("{0:r}");
        yield return new Tuple<string> ("{0:d}");
    }

}

namespace LinkeEngineering.NumeriRomani.UnitTests;


/// <summary>
/// Provides test data for the UnitTests class.
/// </summary>
internal class TestData
{

    /// <summary>
    /// Valid format strings
    /// </summary>


    /// <summary>
    /// A collection of valid Roman numbers and their associated value.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> RomansAndInts()
    {
        yield return new object[] { "", 0 };
        yield return new object[] { "I", 1 };
        yield return new object[] { "II", 2 };
        yield return new object[] { "XLIX", 49 };
        yield return new object[] { "MMXXIII", 2023 };
        yield return new object[] { "ↈↈↈↈↇↂↂↂↂↁMMMMCMXCIX", 499999 };
    }


    /// <summary>
    /// A collection of valid integers and their Roman representation.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> IntsAndRomans()
    {
        foreach (object[] number in RomansAndInts())
        {
            yield return new object[] { number[1], number[0] };
        }
    }


    /// <summary>
    /// A collection of strings that are not valid as Roman numbers.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> InvalidRomans()
    {
        yield return new object[] { "abc" };
        yield return new object[] { "ID" };
        yield return new object[] { "CCCCC" };
        yield return new object[] { "MXDC" };
        yield return new object[] { "ↈↈↈↈↈ" };
    }


    /// <summary>
    /// A collection of integers which can not be written as Roman numbers.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> InvalidInts()
    {
        yield return new object[] { -1 };
        yield return new object[] { 500000 };
    }


    /// <summary>
    /// A collection of values which are not integers.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> NonInts()
    {
        yield return new object[] { "abc" };
        yield return new object[] { "1.23" };
    }


    /// <summary>
    /// A collection of valid format strings to format values as Roman numbers.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> Formats()
    {
        yield return new object[] { "{0}"   };
        yield return new object[] { "{0:g}" };
        yield return new object[] { "{0:G}" };
        yield return new object[] { "{0:R}" };

    }

    /// <summary>
    /// A collection of invvalid format strings to format values as Roman numbers.
    /// </summary>
    /// <returns></returns>
    internal static IEnumerable<object[]> InvalidFormats()
    {
        yield return new object[] { "{1}" };
        yield return new object[] { "{0:r}" };
        yield return new object[] { "{0:d}" };
    }

}

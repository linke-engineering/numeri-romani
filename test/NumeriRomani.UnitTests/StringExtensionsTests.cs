using LinkeEngineering.NumeriRomani.Exceptions;


namespace LinkeEngineering.NumeriRomani.UnitTests;


/// <summary>
/// Tests the <see cref="StringExtensions"/> class.
/// </summary>
[TestClass]
public class StringExtensionsTests
{

    /// <summary>
    /// Tests the <see cref="StringExtensions.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman numeral to be parsed.</param>
    /// <param name="expectedValue">An integer that represents the expected value after the parsing.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.RomansAndInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void ParseRoman_ValidRoman_ReturnsInteger(string roman, int expectedValue)
    {
        // Act
        int actualValue = StringExtensions.ParseRoman(roman);

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }


    /// <summary>
    /// Tests the <see cref="StringExtensions.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman numeral to be parsed.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidRomans), typeof(TestData), DynamicDataSourceType.Method)]
    public void ParseRoman_InvalidRoman_ThrowsInvalidRomanNumberException(string roman)
    {
        // Act and assert
        Assert.ThrowsException<InvalidRomanNumeralException>(() => StringExtensions.ParseRoman(roman));
    }


    /// <summary>
    /// Tests the <see cref="StringExtensions.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman numeral to be parsed.</param>
    /// <param name="expectedValue">An integer that represents the expected value after the parsing.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.RomansAndInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void TryParseRoman_ValidRoman_ReturnsTrue(string roman, int expectedValue)
    {
        // Act
        bool actualSuccess = StringExtensions.TryParseRoman(roman, out int actualValue);

        // Assert
        Assert.IsTrue(actualSuccess);
        Assert.AreEqual(expectedValue, actualValue);
    }


    /// <summary>
    /// Tests the <see cref="StringExtensions.TryParseRoman(string?, out int)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman numeral to be parsed.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidRomans), typeof(TestData), DynamicDataSourceType.Method)]
    public void TryParseRoman_InvalidRoman_ReturnsFalse(string roman)
    {
        // Act
        bool actualSuccess = StringExtensions.TryParseRoman(roman, out int actualValue);

        // Assert
        Assert.IsFalse(actualSuccess);
        Assert.AreEqual(0, actualValue);
    }

}
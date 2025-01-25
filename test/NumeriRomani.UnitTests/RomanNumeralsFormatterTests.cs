using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LinkeEngineering.NumeriRomani.UnitTests;


/// <summary>
/// Tests the <see cref="RomanNumeralsFormatter"/> class.
/// </summary>
[TestClass]
public class RomanNumeralsFormatterTests
{

    #region Local Fields

    /// <summary>
    /// The Roman numerals formatter.
    /// </summary>
    private readonly RomanNumeralsFormatter _formatter = new();

    #endregion


    #region Tests

    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="format">A string that represents the format string.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.Formats), typeof(TestData), DynamicDataSourceType.Method)]
    public void Format_ValidFormat_ReturnsRomanNumber(string format)
    {
        // Act
        string actualString = String.Format(_formatter, format, 2023);

        // Assert
        Assert.AreEqual("MMXXIII", actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    [TestMethod]
    public void Format_EmptyFormat_ReturnsEmpty()
    {
        // Act
        string actualString = String.Format(_formatter, "");

        // Assert
        Assert.AreEqual(String.Empty, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="format">A string that represents the format string.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidFormats), typeof(TestData), DynamicDataSourceType.Method)]
    public void Format_InvalidFormat_ThrowsFormatException(string format)
    {
        // Act and assert
        Assert.ThrowsException<FormatException>(() => String.Format(_formatter, format, 2023));
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    /// <param name="expectedString">A string that represents the Roman numeral.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.IntsAndRomans), typeof(TestData), DynamicDataSourceType.Method)]
    public void Format_ValidInteger_ReturnsRomanNumeral(int number, string expectedString)
    {
        // Act
        string actualString = String.Format(_formatter, "{0:R}", number);

        // Assert
        Assert.AreEqual(expectedString, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void Format_InvalidNumber_ThrowsArgumentOutOfRangeException(int number)
    {
        // Act and assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => String.Format(_formatter, "{0:R}", number));
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="value">An object that represents the value to be formatted.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.NonInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void Format_NonInteger_ThrowsArgumentException(object value)
    {
        // Act and assert
        Assert.ThrowsException<ArgumentException>(() => String.Format(_formatter, "{0:R}", value));
    }

    #endregion

}
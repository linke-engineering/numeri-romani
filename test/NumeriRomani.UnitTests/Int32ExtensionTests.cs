using Sinistrius.NumeriRomani.Exceptions;


namespace Sinistrius.NumeriRomani.UnitTests;


/// <summary>
/// Tests the <see cref="Int32Extension"/> class.
/// </summary>
[TestClass]
public class Int32ExtensionTests
{

    #region ToRoman

    /// <summary>
    /// Tests the <see cref="Int32Extension.ToRoman(int)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    /// <param name="expectedString">A string that represents the Roman number.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.IntsAndRomans), typeof(TestData), DynamicDataSourceType.Method)]
    public void ToRoman_ValidInteger_ReturnsRoman(int number, string expectedString)
    {
        // Act
        string actualString = number.ToRoman();

        // Assert
        Assert.AreEqual(expectedString, actualString);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extension.ToRoman(int)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidInts), typeof(TestData), DynamicDataSourceType.Method)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ToRoman_OutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        // Act
        _ = number.ToRoman();
    }

    #endregion


    #region Parse

    /// <summary>
    /// Tests the <see cref="Int32Extension.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman number to be parsed.</param>
    /// <param name="expectedValue">An integer that represents the expected value after the parsing.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.RomansAndInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void ParseRoman_ValidRoman_ReturnsInteger(string roman, int expectedValue)
    {
        // Act
        int actualValue = Int32Extension.ParseRoman(roman);

        // Assert
        Assert.AreEqual(expectedValue, actualValue);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extension.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman number to be parsed.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidRomans), typeof(TestData), DynamicDataSourceType.Method)]
    [ExpectedException(typeof(InvalidRomanNumberException))]
    public void ParseRoman_InvalidRoman_ThrowsInvalidRomanNumberException(string roman)
    {
        // Act
        _ = Int32Extension.ParseRoman(roman);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extension.Parse(string, IFormatProvider)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman number to be parsed.</param>
    /// <param name="expectedValue">An integer that represents the expected value after the parsing.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.RomansAndInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void TryParseRoman_ValidRoman_ReturnsTrue(string roman, int expectedValue)
    {
        // Act
        bool actualSuccess = Int32Extension.TryParseRoman(roman, out int actualValue);

        // Assert
        Assert.IsTrue(actualSuccess);
        Assert.AreEqual(expectedValue, actualValue);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extension.TryParseRoman(string?, out int)"/> method.
    /// </summary>
    /// <param name="roman">A string that represents the Roman number to be parsed.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidRomans), typeof(TestData), DynamicDataSourceType.Method)]
    public void TryParseRoman_InvalidRoman_ReturnsFalse(string roman)
    {
        // Act
        bool actualSuccess = Int32Extension.TryParseRoman(roman, out int actualValue);

        // Assert
        Assert.IsFalse(actualSuccess);
        Assert.AreEqual(0, actualValue);
    }

    #endregion

}
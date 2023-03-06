namespace Sinistrius.NumeriRomani.UnitTests;


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


    /// <summary>
    /// The allowed format strings to test.
    /// </summary>
    private readonly List<string> _formatStrings = new() { "{0}", "{0:g}", "{0:G}", "{0:R}" };

    #endregion


    #region Tests

    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    /// <param name="expectedString">A string that represents the Roman numeral.</param>
    [TestMethod]
    [DataRow(0, "")]
    [DataRow(1, "I")]
    [DataRow(2, "II")]
    [DataRow(4, "IV")]
    [DataRow(49, "XLIX")]
    [DataRow(101, "CI")]
    [DataRow(1946, "MCMXLVI")]
    [DataRow(388999, "ↈↈↈↇↂↂↂↁMMMCMXCIX")]
    public void Format_ValidInteger_ReturnsRomanNumeral(int number, string expectedString)
    {
        foreach (string formatString in _formatStrings)
        {
            // Act
            string actualString = String.Format(_formatter, formatString, number);

            // Assert
            Assert.AreEqual(expectedString, actualString);
        }
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    [TestMethod]
    public void Format_Empty_ReturnsEmpty()
    {
        // Act
        string actualString = String.Format(_formatter, "");

        // Assert
        Assert.AreEqual(String.Empty, actualString);
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    [TestMethod]
    [DataRow(-1)]
    [DataRow(390000)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ToRoman_OutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        foreach (string formatString in _formatStrings)
        {
            // Act
            _ = String.Format(_formatter, formatString, number);
        }
    }


    /// <summary>
    /// Tests the <see cref="RomanNumeralsFormatter.Format(string?, object?, IFormatProvider?)"/> method.
    /// </summary>
    /// <param name="value">An object that represents the value to be formatted.</param>
    [TestMethod]
    [DataRow("abc")]
    [DataRow(1.23)]
    [ExpectedException(typeof(ArgumentException))]
    public void Format_NonInteger_ThrowsArgumentException(object value)
    {
        foreach (string formatString in _formatStrings)
        {
            // Act
            _ = String.Format(_formatter, formatString, value);
        }
    }

    #endregion

}
namespace Sinistrius.NumeriRomani.UnitTests;


/// <summary>
/// Tests the <see cref="Int32Extension"/> class.
/// </summary>
[TestClass]
public class Int32ExtensionTests
{

    #region Tests

    /// <summary>
    /// Tests the <see cref="Int32Extension.ToRoman(int)"/> method.
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
    public void ToRoman_ValidInteger_ReturnsRomanNumeral(int number, string expectedString)
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
    [TestMethod]
    [DataRow(-1)]
    [DataRow(390000)]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ToRoman_OutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        // Act
        _ = number.ToRoman();
    }

    #endregion

}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;


namespace Sinistrius.NumeriRomani.UnitTests;


[ExcludeFromCodeCoverage]
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
    public void ToRoman_ValidInt32_ReturnsRomanNumeral(int number, string expectedString)
    {
        // Act
        string actualString = number.ToRoman();

        // Assert
        Assert.AreEqual(expectedString, actualString);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extension.ToRoman(int)"/> method.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void ToRoman_NonInteger_ThrowsArgumentException()
    {
        // Act
        _ = (-1).ToRoman();
    }

    #endregion

}
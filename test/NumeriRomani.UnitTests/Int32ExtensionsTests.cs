namespace LinkeEngineering.NumeriRomani.UnitTests;


/// <summary>
/// Tests the <see cref="Int32Extensions"/> class.
/// </summary>
[TestClass]
public class Int32ExtensionsTests
{

    /// <summary>
    /// Tests the <see cref="Int32Extensions.ToRoman(int)"/> method.
    /// </summary>
    /// <param name="value">An integer that represents the value to be formatted.</param>
    /// <param name="expectedString">A string that represents the Roman numeral.</param>
    [TestMethod]
    [DynamicData(nameof(TestData.IntsAndRomans), typeof(TestData))]
    public void ToRoman_ValidInteger_ReturnsRoman(int value, string expectedString)
    {
        // Act
        string actualString = value.ToRoman();

        // Assert
        Assert.AreEqual(expectedString, actualString);
    }


    /// <summary>
    /// Tests the <see cref="Int32Extensions.ToRoman(int)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    [TestMethod]
    [DynamicData(nameof(TestData.InvalidInts), typeof(TestData))]
    public void ToRoman_OutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        // Act and assert
        Assert.Throws<ArgumentOutOfRangeException>(() => number.ToRoman());
    }

}
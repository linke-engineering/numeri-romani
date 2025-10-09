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
    /// Tests the <see cref="Int32Extensions.ToRoman(int)"/> method.
    /// </summary>
    /// <param name="number">An integer that represents the number to be formatted.</param>
    [DataTestMethod]
    [DynamicData(nameof(TestData.InvalidInts), typeof(TestData), DynamicDataSourceType.Method)]
    public void ToRoman_OutOfRange_ThrowsArgumentOutOfRangeException(int number)
    {
        // Act and assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => number.ToRoman());
    }

}
using System.Text;


namespace LinkeEngineering.NumeriRomani;


/// <summary>
/// A mapper for Roman numerals.
/// </summary>
internal class RomanNumeralsMapper
{

    #region Local Fields

    /// <summary>
    /// A dictionary to map integer values to their Roman representation.
    /// </summary>
    private static readonly Dictionary<int, string> _integerToRomanMap = new()
    {
        { 100000, "ↈ" },
        {  50000, "ↇ"  },
        {  10000, "ↂ" },
        {   5000, "ↁ"  },
        {   1000, "M"  },
        {    900, "CM" },
        {    500, "D"  },
        {    400, "CD" },
        {    100, "C"  },
        {     90, "XC" },
        {     50, "L"  },
        {     40, "XL" },
        {     10, "X"  },
        {      9, "IX" },
        {      5, "V"  },
        {      4, "IV" },
        {      1, "I"  }
    };


    /// <summary>
    /// A dictionary to map Roman numerals to their corresponding values.
    /// </summary>
    private readonly Dictionary<char, int> _romanToIntegerMap = new()
    {
        { 'I' ,      1 },
        { 'V' ,      5 },
        { 'X' ,     10 },
        { 'L' ,     50 },
        { 'C' ,    100 },
        { 'D' ,    500 },
        { 'M' ,   1000 },
        { 'ↁ' ,   5000 },
        { 'ↂ',  10000 },
        { 'ↇ' ,  50000 },
        { 'ↈ', 100000 }
    };

    #endregion


    #region Methods

    /// <summary>
    /// Converts a Roman numeral to an integer value.
    /// </summary>
    /// <param name="roman">A string that represents the Roman numeral.</param>
    /// <returns>An integer that represents the value of the Roman numeral.</returns>
    internal int ConvertRomanToInteger(string roman)
    {
        var value = 0;

        for (var i = 0; i < roman.Length; i++)
        {
            if (!_romanToIntegerMap.TryGetValue(roman[i], out int currentValue))
            {
                throw new ArgumentException($"Invalid Roman numeral: {roman[i]}");
            }

            if (i + 1 < roman.Length)
            {
                var nextValue = _romanToIntegerMap[roman[i + 1]];

                if (currentValue < nextValue)
                {
                    value -= currentValue;
                }
                else
                {
                    value += currentValue;
                }
            }
            else
            {
                value += currentValue;
            }
        }

        return value;
    }


    /// <summary>
    /// Converts an integer value to its representation in Roman numerals.
    /// </summary>
    /// <param name="value">An integer that represents the value.</param>
    /// <returns>A string that represents the value written in Roman numerals.</returns>
    internal string ConvertIntegerToRoman(int value)
    {
        var romanBuilder = new StringBuilder();

        foreach (var map in _integerToRomanMap)
        {
            if (value <= 0)
            {
                break;
            }

            while (value >= map.Key)
            {
                romanBuilder.Append(map.Value);
                value -= map.Key;
            }
        }

        return romanBuilder.ToString();
    }

    #endregion

}

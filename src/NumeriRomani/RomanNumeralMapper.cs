using System.Text;


namespace Sinistrius.NumeriRomani;


/// <summary>
/// A mapper for Roman numerals.
/// </summary>
internal class RomanNumeralMapper
{

    #region Local Fields

    /// <summary>
    /// A dictionary to map integer values to their Roman representation.
    /// </summary>
    private readonly Dictionary<int, string> _integerToRomanMap;


    /// <summary>
    /// A dictionary to map Roman numerals to their corresponding values.
    /// </summary>
    private readonly Dictionary<char, int> _romanToIntegerMap;

    #endregion


    #region Constructor

    /// <summary>
    /// Initializes the <see cref="RomanNumeralMapper"/>.
    /// </summary>
    internal RomanNumeralMapper()
    {
        // integer-to-Roman map
        _integerToRomanMap = new()
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

        // Roman-to-integer map is the reversion of a subset of the integer-to-Roman map
        _romanToIntegerMap = _integerToRomanMap.Where(m => m.Value.Length == 1)
                                               .ToDictionary(x => x.Value[0], x => x.Key);
    }

    #endregion


    #region Methods

    /// <summary>
    /// Converts a Roman number to an integer value.
    /// </summary>
    /// <param name="romanNumber">A string that represents the Roman number.</param>
    /// <returns>An integer that represents the value of the Roman number.</returns>
    internal int ConvertRomanToInteger(string romanNumber)
    {
        int value = 0;

        for (int i = 0; i < romanNumber.Length; i++)
        {
            int currentValue = _romanToIntegerMap[romanNumber[i]];

            if (i + 1 < romanNumber.Length)
            {
                int nextValue = _romanToIntegerMap[romanNumber[i + 1]];

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
        StringBuilder stringBuilder = new();

        foreach (KeyValuePair<int, string> roman in _integerToRomanMap)
        {
            if (value <= 0)
            {
                break;
            }

            while (value >= roman.Key)
            {
                stringBuilder.Append(roman.Value);
                value -= roman.Key;
            }
        }

        return stringBuilder.ToString();
    }

    #endregion

}

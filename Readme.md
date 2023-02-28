# Numeri Romani

*Numeri Romani* is a .NET library for dealing with Roman numerals.

Features:
- Convert a non-negative integer to a Roman numeral


## Installation

Use the NuGet Package Manager to install *Numeri Romani*.


## Usage

```cs
using Sinistrius.NumeriRomani;

int number = 123;

// Convert to "CXXIII" using the String.Format() method
RomanNumeralsFormatter formatter = new();
string romanNumeral = String.Format(formatter, "{0:R}", number);

// Convert to "CXXIII" using the ToRoman() extension method
string romanNumeral = number.ToRoman();
```


## License

This work is licensed under a [Creative Commons Attribution-NoDerivatives 4.0 International License](http://creativecommons.org/licenses/by-nd/4.0/).

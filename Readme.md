# Numeri Romani

A .NET library for working with Roman numerals

## Installation

Install *Numeri Romani* using the NuGet Package Manager.

## Restrictions

The library currently supports integers in the range from 0 to 499,999.

## Features

### Format Integers as Roman Numerals

#### Option 1: Extension method for `int`

Use the `ToRoman()` extension method to easily convert an integer to its Roman numeral representation:

```cs
using LinkeEngineering.NumeriRomani;

int number = 123;

string roman = number.ToRoman();
// assigns "CXXIII"
```

#### Option 2: Using `RomanNumeralsFormatter`

For advanced formatting, use the `RomanNumeralsFormatter` with `String.Format()`. Supported format strings are: empty, `"g"`, `"G"`, or `"R"`.

```cs
using LinkeEngineering.NumeriRomani;

int number = 123;

RomanNumeralsFormatter formatter = new();
string roman = String.Format(formatter, "{0:R}", number);
// assigns "CXXIII"
```

### Parse Roman Numerals to Integers

#### Option 1: Parsing With `ParseRoman()`

Use the extensions method `ParseRoman()` to convert a Roman numeral string to its integer value:

```cs
using LinkeEngineering.NumeriRomani;

string roman = "CXXIII";

int number1 = roman.ParseRoman()
// assigns 123
```

#### Option 2: Safe Parsing With `TryParseRoman()`

Use the extension method `TryParseRoman()` to safely parse a Roman numeral string to its integer value:

```cs
using LinkeEngineering.NumeriRomani;

string roman = "CXXIII";

bool isSuccess = roman.TryParseRoman(out int number);
// returns true and assigns 123 to number
```


## License

This work is licensed under a [Creative Commons Attribution-NoDerivatives 4.0 International License](http://creativecommons.org/licenses/by-nd/4.0/).

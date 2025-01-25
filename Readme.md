# Numeri Romani

A .NET library for dealing with Roman numerals


## Installation

Use the NuGet Package Manager to install *Numeri Romani*.


## Usage

### Restrictions

The library currently only works for integers between 0 and 499,999.


### Format Integers as Roman Numbers

#### Option 1: Use an extension method

You can use the *Int32.ToRoman()* extension method to easily format integers as Roman numbers.

```cs
using LinkeEngineering.NumeriRomani;

int number = 123;

string roman = number.ToRoman();
// assigns "CXXIII"
```


#### Option 2: Use a Formatter

A more sophisticated way is to use the *String.Format()* method with a special *RomanNumeralsFormatter()*. In the format string parameter you may omit the format specifier or use the general specifiers *g* or *G* or the special specifier *R*.

```cs
using LinkeEngineering.NumeriRomani;

int number = 123;

RomanNumeralsFormatter formatter = new();
string roman = String.Format(formatter, "{0:R}", number);
// assigns "CXXIII"
```

### Parse Roman Numbers as Integers

To parse a Roman number as an integer, use the *Int32.ParseRoman()* or *Int32.TryParseRoman()* extension methods.

```cs
using LinkeEngineering.NumeriRomani;

string roman = "CXXIII";

int number1 = Int32.ParseRoman(roman)
// assigns 123

bool isSuccess = Int32.TryParseRoman(roman, out int number2);
// returns true and assigns 123 to number2
```


## License

This work is licensed under a [Creative Commons Attribution-NoDerivatives 4.0 International License](http://creativecommons.org/licenses/by-nd/4.0/).

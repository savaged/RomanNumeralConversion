using System.Linq;
using System.Text;

namespace RomanNumeralConversion;

public class Converter
{
    public const int MIN_NUM = 1;
    public const int MAX_NUM = 3999;
    public const string MAX_ROM = "MMMCMXCIX";

    private static readonly RomanNumeralTuple[] RomanNumerals =
    [
        new("M", 1000), new("CM", 900), new("D", 500), new("CD", 400),
        new("C", 100), new("XC", 90), new("L", 50), new("XL", 40),
        new("X", 10), new("IX", 9), new("V", 5), new("IV", 4), new("I", 1)
    ];

    private readonly struct RomanNumeralTuple(string symbol, int value)
    {
        public string Symbol { get; } = symbol;
        public int Value { get; } = value;
    }

    /// <summary>
    /// Converts an integer to its Roman numeral representation.
    /// </summary>
    /// <param name="number">The integer to convert.
    /// Numbers must be between 1 and 3999.
    /// </param>
    /// <returns>The Roman numeral string.</returns>
    public static string Convert(int number)
    {
        if (number <= MIN_NUM)
            return RomanNumerals.Last().Symbol;
        if (number >= MAX_NUM)
            return MAX_ROM;
        return ToRoman(number);
    }

    /// <summary>
    /// Converts a Roman numeral string to its integer representation.
    /// </summary>
    /// <param name="romanNumeral">The Roman numeral string to convert. Case-insensitive.</param>
    /// <returns>The integer representation.</returns>
    public static int Convert(string romanNumeral)
    {
        var total = 0;
        if (romanNumeral?.IsRomanNumeral() != true)
            return total;
        var romanUpper = romanNumeral.ToUpperInvariant();
        var currentIndex = 0;
        while (currentIndex < romanUpper.Length)
        {
            var matched = false;
            foreach (var tuple in RomanNumerals)
            {
                if (romanUpper.Length - currentIndex >= tuple.Symbol.Length &&
                    romanUpper.Substring(currentIndex, tuple.Symbol.Length) == tuple.Symbol)
                {
                    total += tuple.Value;
                    currentIndex += tuple.Symbol.Length;
                    matched = true;
                    break;
                }
            }
            if (!matched)
                break;
        }
        return total;
    }

    private static string ToRoman(int number)
    {
        var sb = new StringBuilder();
        foreach (var tuple in RomanNumerals)
        {
            while (number >= tuple.Value)
            {
                sb.Append(tuple.Symbol);
                number -= tuple.Value;
            }
        }
        return sb.ToString();
    }

}


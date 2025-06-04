using System.Text.RegularExpressions;

namespace RomanNumeralConversion;

public static class StringEx
{
    public static bool IsInt(this string self) => int.TryParse(self, out _);

    public static int ToInt(this string self) => int.TryParse(self, out var i) ? i : 0;

    public static bool IsRomanNumeral(this string self) => 
        !string.IsNullOrWhiteSpace(self) &&
        new Regex("^(?=[MDCLXVI]*$)M*(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$")
        .Match(self).Success;

}

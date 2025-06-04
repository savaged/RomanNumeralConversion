using RomanNumeralConversion;

const string FEEDBACK = "Please include either an integer between 1 and 3999 or a roman numeral.";

if (args is null || args.Length != 1)
{
    Console.WriteLine(FEEDBACK);
    return;
}
if (args[0].IsInt())
    Console.WriteLine(Converter.Convert(args[0].ToInt()));
else if (args[0].IsRomanNumeral())
    Console.WriteLine(Converter.Convert(args[0]));
else
    Console.WriteLine(FEEDBACK);


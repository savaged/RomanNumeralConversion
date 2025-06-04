using RomanNumeralConversion;

namespace RomanNumeralConversionTests;

public class ConveterTests
{
    [Fact]
    public void TestIntToRoman()
    {
        Assert.Equal("I", Converter.Convert(1));
        Assert.Equal("IV", Converter.Convert(4));
        Assert.Equal("IX", Converter.Convert(9));
        Assert.Equal("LVIII", Converter.Convert(58));
        Assert.Equal("MCMXCIV", Converter.Convert(1994));
        Assert.Equal("MMMCMXCIX", Converter.Convert(3999));
        Assert.Equal("I", Converter.Convert(0));
        Assert.Equal("I", Converter.Convert(-5));
    }

    [Fact]
    public void TestRomanToInt()
    {
        Assert.Equal(1, Converter.Convert("I"));
        Assert.Equal(4, Converter.Convert("IV"));
        Assert.Equal(9, Converter.Convert("IX"));
        Assert.Equal(58, Converter.Convert("LVIII"));
        Assert.Equal(1994, Converter.Convert("MCMXCIV"));
        Assert.Equal(3999, Converter.Convert("MMMCMXCIX"));
        Assert.Equal(0, Converter.Convert(""));
        Assert.Equal(0, Converter.Convert("Y"));
        Assert.Equal(0, Converter.Convert("MY"));
        Assert.Equal(0, Converter.Convert("MYX"));
    }

}
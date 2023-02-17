using NUnit.Framework.Internal;
using SimpleRomanCalculator.Converter;

namespace RomanCalculatorTest
{
    public class Tests
    {

        [Test]
        public void ConvertInputToArabicShouldReturnExpectedValue()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            string input1 = "(MMMDCCXXIV - MMCCXXIX) * II";
            List<string> output1 = new List<string> { "(","3724","-","2229",")","*","2" };
            Assert.That(converter.ConvertInputToArabic(input1), Is.EqualTo(output1));           
        }

        [Test]
        public void ConvertInputToArabicShouldThrowsArgumentException()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            string wrongInput1 = "(MMMMDCCXXIV - MMCCXXIX) * II";
            string wrongInput2 = "(MMMDCCXXIV - MMCCXXIX) * IIII";
            Assert.Throws(typeof(ArgumentException), () => converter.ConvertInputToArabic(wrongInput1));
            Assert.Throws(typeof(ArgumentException), () => converter.ConvertInputToArabic(wrongInput2));
            Assert.Throws(typeof(ArgumentException), () => converter.ConvertInputToArabic(null));
            Assert.Throws(typeof(ArgumentException), () => converter.ConvertInputToArabic(""));
        }

        [Test]
        public void RomanToArabicShouldReturnExpectedValue()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            string in1 = "MMMDCCXXIV";
            string in2 = "MMMMDCCXXIV";
            Assert.That(converter.RomanToArabic(in1),Is.EqualTo(3724));
            Assert.That(converter.RomanToArabic(in2), Is.Null);
        }
        [Test]
        public void ArabicToRomanShouldReturnExpectedValue()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            ushort in1 = 1294;
            Assert.That(converter.ArabicToRoman(in1), Is.EqualTo("MCCXCIV"));
        }

        [Test]
        public void ArabicToRomanShouldThrowsArgumentException()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            Assert.Throws(typeof(ArgumentException), () => converter.ArabicToRoman(4001));
        }





    }
    
}
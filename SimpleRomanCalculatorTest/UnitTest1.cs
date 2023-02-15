using NUnit.Framework.Internal;
using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;


namespace RomanCalculatorTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ConvertInputToArabic()
        {
            RomanArabicConverter converter = new RomanArabicConverter();
            string input1 = "(MMMDCCXXIV - MMCCXXIX) * II";
            List<string> output1 = new List<string> { "(","3724","-","2229",")","*","2" };
            Assert.That(converter.ConvertInputToArabic(input1), Is.EqualTo(output1));           
        }

        [Test]
        public void FailConvertInputToArabic()
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
        public void Transform()
        {
            IInfixToPostfix itp= new InfixToPostfix();
            List<string> in1 = (new string[] { "2", "+", "3", "*", "(", "1", "+", "2",")" }).ToList();
            List<String> out1 = (new String[] { "2", "3", "1", "2", "+", "*", "+" }).ToList();
            Assert.That(itp.Transform(in1), Is.EqualTo(out1));   
        }

        [Test] public void FailTransform() {
            IInfixToPostfix itp = new InfixToPostfix();
            List<string> empty = (new string[] { }).ToList();
            Assert.Throws(typeof(ArgumentException), () => itp.Transform(empty));
            Assert.Throws(typeof(ArgumentException), () => itp.Transform(null));
        }

        [Test]
        public void Calculate()
        {
            IPostfixToResult ptr= new PostfixToResult();
            List<String> in1 = (new String[] { "2", "3", "1", "2", "+", "*", "+" }).ToList();
            Assert.That(ptr.Calculate(in1), Is.EqualTo(11));
        }
        [Test]
        public void FailCalculate()
        {
            IPostfixToResult ptr = new PostfixToResult();
            List<string> empty = (new string[] { }).ToList();
            Assert.Throws(typeof(ArgumentException), () => ptr.Calculate(empty));
            Assert.Throws(typeof(ArgumentException), () => ptr.Calculate(null));
        }
        

    }
    
}
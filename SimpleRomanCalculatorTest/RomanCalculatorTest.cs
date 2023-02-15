using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SimpleRomanCalculator;
using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRomanCalculatorTest
{
    internal class RomanCalculatorTest
    {
        [SetUp]
        public void Setup()
        {   
            

        }
        [Test]
        public void RomanCalculatorShoulReturnsExpectedValue()
        {
            var mockRomanArabicConverter = Substitute.For<IRomanArabicConverter>();
            var mockInfixToPostfix = Substitute.For<IInfixToPostfix>();
            var mockPostfixToResult = Substitute.For<IPostfixToResult>();

            string in1 = "(MMMDCCXXIV - MMCCXXIX) * II";
            List<string> convertedInput = new List<string> { "(", "3724", "-", "2229", ")", "*", "2" };
            List<string> postfixInput = new List<string> { "3724","2229","-","2","*" };

            mockRomanArabicConverter.ConvertInputToArabic(in1).Returns(convertedInput);
            mockInfixToPostfix.Transform(convertedInput).Returns(postfixInput);
            mockPostfixToResult.Calculate(postfixInput).Returns((ushort)2990);
            mockRomanArabicConverter.ArabicToRoman(2990).Returns("MMCMXC");

            ICalculator calculator =
               new RomanCalculator(mockRomanArabicConverter, mockInfixToPostfix, mockPostfixToResult);
            Assert.That(calculator.Evaluate(in1), Is.EqualTo("MMCMXC"));
        }

        [Test]
        public void RomanCalculatorShouldThrowsArgumentException()
        {
            var mockRomanArabicConverter = Substitute.For<IRomanArabicConverter>();
            var mockInfixToPostfix = Substitute.For<IInfixToPostfix>();
            var mockPostfixToResult = Substitute.For<IPostfixToResult>();
            string empty = "";
            string wrongInput1 = "(MMMMDCCXXIV - MMCCXXIX) * II";
            List<string> wrongInput2 = (new string[] { "1000", "2001", "-" }).ToList();
            List<string> convertedWrongInput2 = (new string[] {"(", "1000","-", "2001",")"}).ToList();
            string wrongInput3 = "(M-MMI)";
            string wrongInput4 = "(MMM+MMM)";
            List<string> convertedWrongInput4 = (new string[] { "(", "3000", "+", "3000", ")" }).ToList();
            List<string> postfixWrongInput4 = (new string[] { "3000", "3000", "+" }).ToList();

            mockRomanArabicConverter.ConvertInputToArabic(empty).Throws(new ArgumentException());
            mockRomanArabicConverter.ConvertInputToArabic(wrongInput1).Throws(new ArgumentException());
            mockPostfixToResult.Calculate(wrongInput2).Throws(new ArgumentException());
            mockRomanArabicConverter.ConvertInputToArabic(wrongInput3).Returns(convertedWrongInput2);
            mockInfixToPostfix.Transform(convertedWrongInput2).Returns(wrongInput2);
            mockRomanArabicConverter.ArabicToRoman(6000).Throws(new ArgumentException());

            mockRomanArabicConverter.ConvertInputToArabic(wrongInput4).Returns(convertedWrongInput4);
            mockInfixToPostfix.Transform(convertedWrongInput4).Returns(postfixWrongInput4);
            mockPostfixToResult.Calculate(postfixWrongInput4).Returns((ushort)6000);


            ICalculator calculator =
              new RomanCalculator(mockRomanArabicConverter, mockInfixToPostfix, mockPostfixToResult);
            Assert.Throws(typeof(ArgumentException), () => calculator.Evaluate(empty));
            Assert.Throws(typeof(ArgumentException), () => calculator.Evaluate(wrongInput1));
            Assert.Throws(typeof(ArgumentException), () => calculator.Evaluate(wrongInput3));
            Assert.Throws(typeof(ArgumentException), () => calculator.Evaluate(wrongInput4));
        }
    }
}

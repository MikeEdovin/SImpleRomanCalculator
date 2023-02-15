using SimpleRomanCalculator.Parser;

namespace SimpleRomanCalculatorTest
{
    internal class PostfixToResultTest
    {

        [Test]
        public void CalculateShouldReturnExpectedValue()
        {
            IPostfixToResult ptr = new PostfixToResult();
            List<String> in1 = (new String[] { "2", "3", "1", "2", "+", "*", "+" }).ToList();
            Assert.That(ptr.Calculate(in1), Is.EqualTo(11));
        }
        [Test]
        public void CalculateShouldThrowsArgumentException()
        {
            IPostfixToResult ptr = new PostfixToResult();
            List<string> empty = (new string[] { }).ToList();
            List<string> wrongInput1= (new string[] { "1000", "2001", "-" }).ToList();
            Assert.Throws(typeof(ArgumentException), () => ptr.Calculate(empty));
            Assert.Throws(typeof(ArgumentException), () => ptr.Calculate(null));
            Assert.Throws(typeof(ArgumentException), () => ptr.Calculate(wrongInput1));
        }

    }
}

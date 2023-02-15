using SimpleRomanCalculator.Parser;

namespace SimpleRomanCalculatorTest
{
    internal class InfixToPostfixTest
    {
        [Test]
        public void TransformShouldReturnExpectedValue()
        {
            IInfixToPostfix itp = new InfixToPostfix();
            List<string> in1 = (new string[] { "2", "+", "3", "*", "(", "1", "+", "2", ")" }).ToList();
            List<String> out1 = (new String[] { "2", "3", "1", "2", "+", "*", "+" }).ToList();
            Assert.That(itp.Transform(in1), Is.EqualTo(out1));
        }

        [Test]
        public void TransformShouldThrowsArgumentException()
        {
            IInfixToPostfix itp = new InfixToPostfix();
            List<string> empty = (new string[] { }).ToList();
            Assert.Throws(typeof(ArgumentException), () => itp.Transform(empty));
            Assert.Throws(typeof(ArgumentException), () => itp.Transform(null));
        }
    }
}

using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;

namespace SimpleRomanCalculator
{
    public class RomanCalculator: ICalculator
    {
        IRomanArabicConverter converter;
        IInfixToPostfix itp;
        IPostfixToResult ptr;

        public RomanCalculator(IRomanArabicConverter converter, 
            IInfixToPostfix itp,
            IPostfixToResult ptr) { 
            this.converter = converter;
            this.itp = itp;
            this.ptr = ptr;
        }
        
        public string Evaluate(string input) 
        {
                List<string> arabicInput = converter.ConvertInputToArabic(input);
                List<string> postfixInput = itp.Transform(arabicInput);
                ushort result = ptr.Calculate(postfixInput);
                return converter.ArabicToRoman(result);
        }
    }
}
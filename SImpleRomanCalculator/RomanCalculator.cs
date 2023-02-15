using SimpleRomanCalculator.Converter;
using SimpleRomanCalculator.Parser;

namespace SimpleRomanCalculator
{
    public class RomanCalculator: Calculator
    {
        public RomanCalculator() { 
        }
        IInfixToPostfix itp=new InfixToPostfix();
        RomanArabicConverter converter = new RomanArabicConverter();
        IPostfixToResult ptr = new PostfixToResult();

        public string Evaluate(string input)
        {
            try
            {
                List<string> arabicInput = converter.ConvertInputToArabic(input);
                List<string> postfixInput = itp.Transform(arabicInput);
                ushort result = ptr.Calculate(postfixInput);
                return converter.ArabicToRoman(result);
            }
            catch(ArgumentException e)
            {
                return e.Message;
            }
           
           

           
            
        }
    }
}
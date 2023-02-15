namespace SimpleRomanCalculator.Parser
{
    public interface IInfixToPostfix
    {
         List<string> Transform(List<string> infixInput);
    }
}

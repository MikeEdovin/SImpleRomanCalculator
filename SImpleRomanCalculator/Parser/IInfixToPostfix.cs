namespace SimpleRomanCalculator.Parser
{
    public interface IInfixToPostfix
    {
        abstract List<string> Transform(List<string> infixInput);
    }
}

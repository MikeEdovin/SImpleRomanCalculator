namespace SimpleRomanCalculator.Parser
{
    public interface IPostfixToResult
    {
        ushort Calculate(List<string> postfixString);
    }
}

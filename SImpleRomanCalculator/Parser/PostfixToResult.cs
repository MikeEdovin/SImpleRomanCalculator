namespace SimpleRomanCalculator.Parser
{
    public class PostfixToResult: IPostfixToResult
    {
        private Stack<ushort> stack = new Stack<ushort>();


        public ushort Calculate(List<string> postfixString)
        {
            if (postfixString is null || postfixString.Count == 0)
            {
                throw new ArgumentException("Input can't be empty");
            }
                string item;
                int j;
                ushort num1, num2, answer;
            try
            {
                for (j = 0; j < postfixString.Count; j++)
                {
                    item = postfixString[j];
                    if (!IsOperator(item))
                    {
                        stack.Push(ushort.Parse(item));
                    }
                    else
                    {
                        num2 = stack.Pop();
                        num1 = stack.Pop();
                        switch (item)
                        {
                            case "+":
                                answer = (ushort)(num1 + num2);
                                break;
                            case "-":
                                answer = (ushort)(num1 - num2);
                                break;
                            case "*":
                                answer = (ushort)(num1 * num2);
                                break;
                            case "/":
                                answer = (ushort)(num1 / num2);
                                break;
                            default:
                                answer = 0;
                                break;
                        }
                        stack.Push(answer);
                    }
                }
                return stack.Pop();
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message+" can't be converted to digit");
            }
   
        }

        private bool IsOperator(string item)
        {
            return item.Equals("+") || item.Equals("-") || item.Equals("*") || item.Equals("/");

        }
    }
}

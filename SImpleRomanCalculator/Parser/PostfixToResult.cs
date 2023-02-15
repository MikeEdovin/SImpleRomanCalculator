namespace SimpleRomanCalculator.Parser
{
    public class PostfixToResult: IPostfixToResult
    {
        private Stack<int> stack = new Stack<int>();


        public ushort Calculate(List<string> postfixInput)
        {
            if (postfixInput is null || postfixInput.Count == 0)
            {
                throw new ArgumentException("Input can't be empty");
            }
                string item;
                int j;
                int num1, num2, answer;
            try
            {
                for (j = 0; j < postfixInput.Count; j++)
                {
                    item = postfixInput[j];
                    if (!IsOperator(item))
                    {
                        stack.Push(int.Parse(item));
                    }
                    else
                    {
                        num2 = stack.Pop();
                        num1 = stack.Pop();
                        switch (item)
                        {
                            case "+":
                                answer = num1 + num2;
                                break;
                            case "-":
                                answer = num1 - num2;
                                break;
                            case "*":
                                answer = num1 * num2;
                                break;
                            case "/":
                                answer = num1 / num2;
                                break;
                            default:
                                answer = 0;
                                break;
                        }

                        stack.Push(answer);
                    }
                }
                if (stack.Peek() > 0)
                {
                    return (ushort)stack.Pop();
                }
                else
                {
                    throw new ArgumentException("Result can't be negative");
                }
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

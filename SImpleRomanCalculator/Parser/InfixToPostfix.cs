namespace SimpleRomanCalculator.Parser
{



    public class InfixToPostfix: IInfixToPostfix
    {
        private Stack<string> stack = new Stack<string>();

        public List<string> Transform(List<string> infixInput)
        {
            if (infixInput is null||infixInput.Count == 0)
            {
                throw new ArgumentException("Input can't be empty");
            }
            
                List<string> postfixOutput = new List<string>();
                for (int i = 0; i < infixInput.Count; i++)
                {
                    string item = infixInput[i];
                    switch (item)
                    {
                        case "+":
                        case "-":
                            GotOperator(item, 1, postfixOutput);
                            break;
                        case "*":
                        case "/":
                            GotOperator(item, 2, postfixOutput);
                            break;
                        case "(":
                            stack.Push(item);
                            break;
                        case ")":
                            GotClosingBracket(item, postfixOutput);
                            break;
                        default:
                            postfixOutput.Add(item);
                            break;
                    }
                }
                while (stack.Count > 0)
                {
                    postfixOutput.Add(stack.Pop());
                }
                return postfixOutput;
        }
        private void GotOperator(string opThis, int priorityThis, List<string> output)
        {
            while (stack.Count > 0)
            {
                String opTop = stack.Pop();
                if (opTop.Equals("("))
                {
                    stack.Push(opTop);
                    break;
                }
                else
                {
                    int priorityTop;
                    if (opTop.Equals("+") || opTop.Equals("-"))
                    {
                        priorityTop = 1;
                    }
                    else
                    {
                        priorityTop = 2;
                    }
                    if (priorityTop < priorityThis)
                    {
                        stack.Push(opTop);
                        break;
                    }
                    else
                    {
                        output.Add(opTop);
                    }
                }
            }
            stack.Push(opThis);

        }

        private void GotClosingBracket(string bracket, List<string> output)
        {
            while (stack.Count > 0)
            {
                String item = stack.Pop();
                if (item.Equals("("))
                {
                    break;
                }
                else
                {
                    output.Add(item);
                }
            }

        }

    }

}     
    



    

  


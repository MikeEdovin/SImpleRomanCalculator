using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRomanCalculator.Parser
{
    public interface IPostfixToResult
    {
        abstract ushort Calculate(List<string> postfixString);
    }
}

# RomanCalculator

Hi there!
This is a simple calculator that returns the result of arithmetic operations with Roman numbers.
Main class RomanCalculator need three dependencies-IRomanArabicConverter,IInfixToPostfix and IpostfixToResult.
You can use built-in realisations or create your own.
Main method - string Evaluate(string input).
Input format: string with the expression.
Output format:string with result.
It has some limitations:
1. Number's range 1-3999 in input and in output
2. Roman numbers must have <=3 digits of the same range

If everything is ok it returns result, if not - throws ArgumentException with the description of the problem.

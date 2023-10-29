using Rpn;
using Rpn.Operations;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace RpnCalculator
{
    public class Rpn
    {
        private const char STRING_INPUT_ENTRIES_SEPARATOR = ' ';

        private readonly MathOperationFactory _operationFactory;

        public Rpn()
        {
            _operationFactory = new MathOperationFactory();
        }

        public int EvalRPN(string input)
        {
            var operators = new Stack<int>();
            var splitInput = input.Split(new char[] { STRING_INPUT_ENTRIES_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var op in splitInput)
            {
                if (IsNumber(op))
                {
                    operators.Push(Int32ParserDecorator.ToInt32(op));
                }
                else if (IsOperator(op))
                {
                    operators.Push(_operationFactory.Create(op).GetValue(operators));
                }
                else
                {
                    throw new ArgumentException("Unrecognized argument(s). One or more arguments are invalid or have not been implemented yet.");
                }
            }

            var result = operators.Pop();
            return operators.IsEmpty ? result : throw new InvalidOperationException();
        }

        /// <summary>
        /// RegExp created with the following ChatGPT prompt:
        /// I need a C# compliant regular expression that would match
        /// any hexadecimal number starting with '0x' and 
        /// any binary number starting with '0b' and 
        /// any positive or negative decimal number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsNumber(string input) => Regex.IsMatch(input, @"^(-?\d+|0x[0-9A-Fa-f]+|0b[01]+)$");

        private bool IsOperator(string input) => MathOperation.SupportedOperations.Keys.Contains(input);
    }
}
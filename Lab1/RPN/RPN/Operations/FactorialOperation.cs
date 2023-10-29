using Rpn.Operations;
using System;

namespace RPN.Operations
{
    public class FactorialOperation : MathOperation
    {
        public override int GetValue(RpnCalculator.Stack<int> operators)
        {
            var num = operators.Pop();
            var product = 1;

            if (num < 0)
            {
                throw new InvalidOperationException("Factorial arguments cannot be negative.");
            }

            for (var i = num; i > 1; i--)
            {
                product *= i;
            }

            return product;
        }
    }
}

using Rpn.Operations;

namespace RPN.Operations
{
    internal class SubtractOperation : MathOperation
    {
        public override int GetValue(RpnCalculator.Stack<int> operators)
        {
            return operators.Pop() - operators.Pop();
        }
    }
}

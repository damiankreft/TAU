using Rpn.Operations;

namespace RPN.Operations
{
    public class AddOperation : MathOperation
    {
        public override int GetValue(RpnCalculator.Stack<int> operators)
        {
            // Implement exception handling
            return operators.Pop() + operators.Pop();
        }
    }
}

using Rpn.Operations;
using RpnCalculator;

namespace RPN.Operations
{
    public class DivideOperation : MathOperation
    {
        public override int GetValue(Stack<int> operators)
        {
            return operators.Pop() / operators.Pop();
        }
    }
}

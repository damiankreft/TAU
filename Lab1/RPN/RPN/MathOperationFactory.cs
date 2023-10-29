using Rpn.Operations;
using System;

namespace Rpn
{
    public class MathOperationFactory
    {
        public MathOperation Create(string input) => MathOperation.SupportedOperations.TryGetValue(input, out var result)
                ? (MathOperation)Activator.CreateInstance(result)
                : null;
    }
}

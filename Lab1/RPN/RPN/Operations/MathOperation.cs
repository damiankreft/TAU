using RPN.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rpn.Operations
{
    public abstract class MathOperation
    {
        public static readonly ReadOnlyDictionary<string, Type> SupportedOperations = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>()
        {
            ["+"] = typeof(AddOperation),
            ["-"] = typeof(SubtractOperation),
            ["*"] = typeof(MultiplyOperation),
            ["/"] = typeof(DivideOperation),
            ["!"] = typeof(FactorialOperation)
        });

        public abstract int GetValue(RpnCalculator.Stack<int> operators);
    }
}

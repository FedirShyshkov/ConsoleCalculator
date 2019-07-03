using ConsoleCalculatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculatorLibrary.Expressions
{
    class UnaryExpression : IExpressionNode
    {
        public UnaryExpression(IExpressionNode rhs, Func<double, double> operation)
        {
            _rhs = rhs;
            _operation = operation;
        }

        IExpressionNode _rhs;                  
        readonly Func<double, double> _operation;               

        public double Evaluate()
        {
            var rhsVal = _rhs.Evaluate();

            var result = _operation(rhsVal);
            return result;
        }
    }
}

using ConsoleCalculatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculatorLibrary.Expressions
{
    public class BinaryExpression : IExpressionNode
    {
        IExpressionNode _leftNode;
        IExpressionNode _rightNode;
        Func<double, double, double> _operation;

        public BinaryExpression(IExpressionNode leftNode, IExpressionNode rightNode, Func<double, double, double> operation)
        {
            _leftNode = leftNode;
            _rightNode = rightNode;
            _operation = operation;
        }

        public double Evaluate()
        {
            var lhsVal = _leftNode.Evaluate();
            var rhsVal = _rightNode.Evaluate();

            var result = _operation(lhsVal, rhsVal);
            return result;
        }
    }
}

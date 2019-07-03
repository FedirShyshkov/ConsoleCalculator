using ConsoleCalculatorLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleCalculatorLibrary.Expressions
{
    public class ValueExpression : IExpressionNode
    {
        readonly private double _value;

        public ValueExpression(double value)
        {
            _value = value;
        }
        public double Evaluate()
        {
            return _value;
        }
    }
}

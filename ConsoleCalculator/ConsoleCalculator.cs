using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleCalculatorLibrary
{
    public class ConsoleCalculator : ICalculator
    {
        public enum Lexema
        {
            Number,
            Add,
            Subtract,
        }

        struct Node
        {
            readonly public Lexema lexema;
            readonly public double value;

            public Node(Lexema lex)
            {
                lexema = lex;
                value = 0;
            }

            public Node(double _value)
            {
                lexema = Lexema.Number;
                value = _value;
            }
        }

        public double Calculate(string inputExpression)
        {
            var parsedExpression = Parse(inputExpression);

            return Evaluate(parsedExpression);
        }

        private LinkedList<Node> Parse(string inputString)
        {
            char[] inputCharacters = inputString.ToCharArray();
            var charArrayLength = inputCharacters.Length;
            var outputList = new LinkedList<Node>();

            double _number = 0;
            var currentNumberExpression = new StringBuilder();
            bool haveDecimalPoint = false;

            for (int i = 0; i <= charArrayLength; i++)
            {
                if (i == charArrayLength && currentNumberExpression.Length > 0)
                {
                    _number = double.Parse(currentNumberExpression.ToString(), CultureInfo.InvariantCulture);
                    outputList.AddLast(new Node(_number));
                    break;
                }                

                char _currentChar = inputCharacters[i];

                if (char.IsWhiteSpace(_currentChar))
                {
                    continue;
                }
                if (char.IsDigit(_currentChar) || _currentChar == '.')
                {

                    if (char.IsDigit(_currentChar) || (!haveDecimalPoint && _currentChar == '.'))
                    {
                        currentNumberExpression.Append(_currentChar);
                        haveDecimalPoint = _currentChar == '.';
                        continue;
                    }
                }
                if (currentNumberExpression.Length > 0)
                {
                    _number = double.Parse(currentNumberExpression.ToString(), CultureInfo.InvariantCulture);
                    outputList.AddLast(new Node(_number));
                    currentNumberExpression = new StringBuilder();
                    haveDecimalPoint = false;
                    _number = 0;
                }
                switch (_currentChar)
                {
                    case '+':
                        outputList.AddLast(new Node(Lexema.Add));
                        continue;
                    case '-':
                        outputList.AddLast(new Node(Lexema.Subtract));
                        continue;
                }
                throw new ArithmeticException($"Not supported character {_currentChar} in expression {inputString}");
            }
            return outputList;
        }

        private double Evaluate(LinkedList<Node> parsedExpression)
        {
            var currentNode = parsedExpression.First.Value;
            parsedExpression.RemoveFirst();
            if (currentNode.lexema == Lexema.Number)
            {
                double currentValue = currentNode.value;
                return EvaluateRight(parsedExpression, currentValue);
            }
            if (currentNode.lexema == Lexema.Subtract)
            {
                double currentValue = -1 * parsedExpression.First.Value.value;
                parsedExpression.RemoveFirst();
                if (parsedExpression.First != null)
                {
                    return EvaluateRight(parsedExpression, currentValue);
                } else
                {
                    return currentValue;
                }
            }
            throw new ArithmeticException($"Failed to evaluate input string");
        }
        private double EvaluateRight(LinkedList<Node> parsedExpression, double initialValue)
        {
            double lhs = initialValue;
            switch (parsedExpression.First.Value.lexema)
            {
                case Lexema.Add:
                    parsedExpression.RemoveFirst();
                    if (parsedExpression.First.Value.lexema == Lexema.Number)
                    {
                        if (parsedExpression.First.Next != null)
                        {
                            if ((int)parsedExpression.First.Next.Value.lexema > 2)
                            {
                                lhs = lhs + Evaluate(parsedExpression);
                            }
                            else
                            {
                                lhs = lhs + parsedExpression.First.Value.value;
                                parsedExpression.RemoveFirst();
                                lhs = EvaluateRight(parsedExpression, lhs);
                            }
                        }
                        else
                        {
                            lhs = lhs + parsedExpression.First.Value.value;
                        }
                    }
                    else if (parsedExpression.First.Value.lexema == Lexema.Subtract)
                    {
                        lhs = lhs + Evaluate(parsedExpression);
                    }
                    break;
                case Lexema.Subtract:
                    parsedExpression.RemoveFirst();
                    if (parsedExpression.First.Value.lexema == Lexema.Number)
                    {
                        if (parsedExpression.First.Next != null)
                        {
                            if ((int)parsedExpression.First.Next.Value.lexema > 2)
                            {
                                lhs = lhs - Evaluate(parsedExpression);
                            }
                            else
                            {
                                lhs = lhs - parsedExpression.First.Value.value;
                                parsedExpression.RemoveFirst();
                                lhs = EvaluateRight(parsedExpression, lhs);
                            }
                        }
                        else
                        {
                            lhs = lhs - parsedExpression.First.Value.value;
                        }
                    }
                    else if (parsedExpression.First.Value.lexema == Lexema.Subtract)
                    {
                        lhs = lhs - Evaluate(parsedExpression);
                    }
                    break;
            }
            return lhs;
        }
    }
}

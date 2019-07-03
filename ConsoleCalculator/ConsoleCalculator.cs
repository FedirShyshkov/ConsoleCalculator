using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ConsoleCalculatorLibrary.Expressions;
using ConsoleCalculatorLibrary.Interfaces;
using ConsoleCalculatorLibrary.Tokens;

namespace ConsoleCalculatorLibrary
{
    public class ConsoleCalculator : ICalculator
    {
        internal Queue<LexemaNode> parsedExpression;

        public double Calculate(string inputExpression)
        {
            Parse(inputExpression);

            return CalculateExpression().Evaluate();
        }

        protected IExpressionNode CalculateExpression()
        {
            var expr = CalculateAddSubtract();
            if (parsedExpression.Peek().LexicalElement != Lexema.EOF)
                throw new ArgumentException("Unexpected characters at end of expression");

            return expr;
        }

        protected IExpressionNode CalculateAddSubtract()
        {
            var lhs = CalculateMultiplyDivide();

            while (true)
            {
                Func<double, double, double> operation = null;
                var currentLexemaNode = parsedExpression.Peek();
                if (currentLexemaNode.LexicalElement == Lexema.Add)
                {
                    operation = (a, b) => a + b;
                }
                else if (currentLexemaNode.LexicalElement == Lexema.Subtract)
                {
                    operation = (a, b) => a - b;
                }

                if (operation == null)
                    return lhs;

                parsedExpression.Dequeue();

                var rhs = CalculateMultiplyDivide();

                lhs = new BinaryExpression(lhs, rhs, operation);
            }
        }

        protected IExpressionNode CalculateMultiplyDivide()
        {
            var lhs = CalculateUnary();

            while (true)
            {
                Func<double, double, double> operation = null;
                var currentLexemaNode = parsedExpression.Peek();
                if (currentLexemaNode.LexicalElement == Lexema.Multiply)
                {
                    operation = (a, b) => a * b;
                }
                else if (currentLexemaNode.LexicalElement == Lexema.Divide)
                {
                    operation = (a, b) => a / b;
                }

                if (operation == null)
                    return lhs;

                parsedExpression.Dequeue();

                var rhs = CalculateUnary();

                lhs = new BinaryExpression(lhs, rhs, operation);
            }
        }

        protected IExpressionNode CalculateLeaf()
        {
            var currentLexemaNode = parsedExpression.Peek();
            if (currentLexemaNode.LexicalElement == Lexema.Number)
            {
                var node = new ValueExpression(currentLexemaNode.value);
                parsedExpression.Dequeue();
                return node;
            }

            if (currentLexemaNode.LexicalElement == Lexema.OpenBracket)
            {
                parsedExpression.Dequeue();

                var node = CalculateAddSubtract();
                currentLexemaNode = parsedExpression.Peek();
                if (currentLexemaNode.LexicalElement != Lexema.CloseBracket)
                    throw new ArgumentException("Parenthesis arent closed in input expression");
                parsedExpression.Dequeue();

                return node;
            }

            if(currentLexemaNode.LexicalElement == Lexema.EOF)
            {
                throw new ArgumentException("No input expression found");
            }
            throw new ArgumentException($"Unexpected lexema: {currentLexemaNode.LexicalElement}");
        }

        IExpressionNode CalculateUnary()
        {
            var currentLexemaNode = parsedExpression.Peek();
            if (currentLexemaNode.LexicalElement == Lexema.Add)
            {
                parsedExpression.Dequeue();
                return CalculateUnary();
            }

            if (currentLexemaNode.LexicalElement == Lexema.Subtract)
            {
                parsedExpression.Dequeue();

                var rhs = CalculateUnary();
                
                return new UnaryExpression(rhs, (a) => -a);
            }

            return CalculateLeaf();
        }

        protected void Parse(string inputString)
        {
            char[] inputCharacters = inputString.ToCharArray();
            var charArrayLength = inputCharacters.Length;
            var outputQueue = new Queue<LexemaNode>();

            double _number = 0;
            var currentNumberExpression = new StringBuilder();
            bool haveDecimalPoint = false;

            for (int i = 0; i < charArrayLength; i++)
            {              
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
                    outputQueue.Enqueue(new LexemaNode(_number));
                    currentNumberExpression = new StringBuilder();
                    haveDecimalPoint = false;
                    _number = 0;
                }
                switch (_currentChar)
                {
                    case '+':
                        outputQueue.Enqueue(new LexemaNode(Lexema.Add));
                        continue;
                    case '-':
                        outputQueue.Enqueue(new LexemaNode(Lexema.Subtract));
                        continue;
                    case '*':
                        outputQueue.Enqueue(new LexemaNode(Lexema.Multiply));
                        continue;
                    case '/':
                        outputQueue.Enqueue(new LexemaNode(Lexema.Divide));
                        continue;
                    case '(':
                        outputQueue.Enqueue(new LexemaNode(Lexema.OpenBracket));
                        continue;
                    case ')':
                        outputQueue.Enqueue(new LexemaNode(Lexema.CloseBracket));
                        continue;
                }
                throw new ArgumentException($"Not supported character {_currentChar} in expression {inputString}");
            }
            if (currentNumberExpression.Length > 0)
            {
                _number = double.Parse(currentNumberExpression.ToString(), CultureInfo.InvariantCulture);
                outputQueue.Enqueue(new LexemaNode(_number));
            }
            outputQueue.Enqueue(new LexemaNode(Lexema.EOF));
            parsedExpression = outputQueue;
        }
        
    }
}

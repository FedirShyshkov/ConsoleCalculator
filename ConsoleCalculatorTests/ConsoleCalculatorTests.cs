using System;
using ConsoleCalculatorLibrary;
using Xunit;

namespace ConsoleCalculatorTests
{
    public class ConsoleCalculatorTests
    {
        [Fact]
        public void Calculate_should_return_2_if_input_expression_is_1_plus_1()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1+1";
            double expected = 2;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_2()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1+2";
            double expected = 3;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_1_plus_1()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1+1+1";
            double expected = 3;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_1_plus_1_plus_1()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1+1+1+1";
            double expected = 4;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_0_if_input_expression_is_1_minus_1()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1-1";
            double expected = 0;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_1_if_input_expression_is_1_minus_1_minus_1()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1-1-1";
            double expected = -1;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_4_if_input_expression_is_1_minus_2_minus_3()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "1-2-3";
            double expected = -4;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_6_if_input_expression_is_minus_1_minus_2_minus_3()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "-1-2-3";
            double expected = -6;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_6_if_input_expression_is_minus_3_minus_3_plus_2_minus_minus_3()
        {
            var sut = new ConsoleCalculator();
            var inputExpression = "-3-3+2--3";
            double expected = -1;

            var result = sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }
    }
}

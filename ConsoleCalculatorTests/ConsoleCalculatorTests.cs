using System;
using ConsoleCalculatorLibrary;
using Xunit;

namespace ConsoleCalculatorTests
{
    public class ConsoleCalculatorTests
    {
        ConsoleCalculator _sut;

        public ConsoleCalculatorTests()
        {
            _sut = new ConsoleCalculator();
        }

        [Fact]
        public void Calculate_should_return_2_if_input_expression_is_1_plus_1()
        {            
            var inputExpression = "1+1";
            double expected = 2;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_2()
        {
            var inputExpression = "1+2";
            double expected = 3;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_1_plus_1()
        {
            var inputExpression = "1+1+1";
            double expected = 3;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_3_if_input_expression_is_1_plus_1_plus_1_plus_1()
        {
            var inputExpression = "1+1+1+1";
            double expected = 4;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_0_if_input_expression_is_1_minus_1()
        {
            var inputExpression = "1-1";
            double expected = 0;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_1_if_input_expression_is_1_minus_1_minus_1()
        {
            var inputExpression = "1-1-1";
            double expected = -1;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_4_if_input_expression_is_1_minus_2_minus_3()
        {
            var inputExpression = "1-2-3";
            double expected = -4;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_6_if_input_expression_is_minus_1_minus_2_minus_3()
        {
            var inputExpression = "-1-2-3";
            double expected = -6;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_6_if_input_expression_is_minus_3_minus_3_plus_2_minus_minus_3()
        {
            var inputExpression = "-3-3+2--3";
            double expected = -1;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_2_if_input_expression_is_1_multiply_2()
        {
            var inputExpression = "1*2";
            double expected = 2;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_2_if_input_expression_is_1_minus_1_multiply_2_plus_4_multiply_3()
        {
            var inputExpression = "1-1*2+4*3";
            double expected = 11;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_if_input_expression_is_2_divide_2()
        {
            var inputExpression = "2/2";
            double expected = 1;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_0_if_input_expression_is_2_divide_2_minus_1()
        {
            var inputExpression = "2/2-1";
            double expected = 0;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_if_input_expression_is_2_divide_2_multiply_3_add_3()
        {
            var inputExpression = "2/2*3+3";
            double expected = 6;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_if_input_expression_is_1_minus_openbracket_one_plus_one_closebracket()
        {
            var inputExpression = "1-(1+1)";
            double expected = -1;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_if_input_expression_is_4_divide_2_multiply_by_open_bracket_1_add_1_close_bracket()
        {
            var inputExpression = "4/2*(1+1)";
            double expected = 4;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_2_point_5_if_input_expression_is_1_point_5_plus_1()
        {
            var inputExpression = "1.5+1";
            double expected = 2.5;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_point_5_if_input_expression_is_1_point_5()
        {
            var inputExpression = "1.5";
            double expected = 1.5;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_1_point_5_if_input_expression_is_plus_1_point_5()
        {
            var inputExpression = "+1.5";
            double expected = 1.5;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Calculate_should_return_minus_1_point_5_if_input_expression_is_minus_1_point_5()
        {
            var inputExpression = "-1.5";
            double expected = -1.5;

            var result = _sut.Calculate(inputExpression);

            Assert.Equal(expected, result);
        }
    }
}

using Xunit;

namespace Calculator
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldDoAdiition()
        {
            double result = Calculator.DoOperation(1, 2, "a");
            Assert.Equal(3, result);
        }

        [Fact]
        public void ShouldDoSubtract()
        {
            double result = Calculator.DoOperation(1, 2, "s");
            Assert.Equal(-1, result);
        }

        [Fact]
        public void ShouldDoMultiply()
        {
            double result = Calculator.DoOperation(1, 2, "m");
            Assert.Equal(2, result);
        }

        [Fact]
        public void ShouldDoDivide()
        {
            double result = Calculator.DoOperation(4, 2, "d");
            Assert.Equal(2, result);
        }

        [Fact]
        public void ShouldDoNotDivide()
        {
            double result = Calculator.DoOperation(4, 0, "d");
            Assert.Equal(double.NaN, result);
        }

        [Fact]
        public void ShouldDoNothink()
        {
            double result = Calculator.DoOperation(4, 0, "n");
            Assert.Equal(double.NaN, result);
        }
    }
}
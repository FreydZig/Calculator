using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        //[Fact]
        //public void ShouldRunAndReturnResultOfAdding()
        //{
        //    StringWriter _stringWriter = new StringWriter();
        //    Console.SetOut(_stringWriter);

        //    StringBuilder _stringBuilder = new StringBuilder();

        //    _stringBuilder.AppendLine("!");
        //    _stringBuilder.AppendLine("4");
        //    _stringBuilder.AppendLine("(");
        //    _stringBuilder.AppendLine("5");
        //    _stringBuilder.AppendLine("a");
        //    _stringBuilder.AppendLine("n");
        //    StringReader _stringReader = new StringReader(_stringBuilder.ToString());
        //    Console.SetIn(_stringReader);

        //    Program.Main(new string[0]);
        //    var expectedResult = "Console Calculator in C#" +
        //                         "------------------------" +
        //                         "Type a number, and then press Enter: " +
        //                         "This is not valid input. Please enter an integer value: " +
        //                         "Type another number, and then press Enter: " +
        //                         "This is not valid input. Please enter an integer value: " +
        //                         "Choose an operator from the following list:" +
        //                         "a - Add" +
        //                         "s - Subtract" +
        //                         "m - Multiply" +
        //                         "d - Divide" +
        //                         "Your option? " +
        //                         "Your result: 9" +
        //                         "------------------------" +
        //                         "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

        //    Assert.Equal(expectedResult, Regex.Replace(_stringWriter.ToString(), @"[\r\t\n]+", string.Empty));
        //}

        [Fact]
        public void ShouldReturnErrorOfDivide()
        {

            MockConsole mockConsole = new MockConsole();
            Program program = new Program();
            program.MyConsole = mockConsole;

            StringBuilder _stringBuilder = new StringBuilder();

            mockConsole.Outputs.Enqueue("2");
            mockConsole.Outputs.Enqueue("0");
            mockConsole.Outputs.Enqueue("d");
            mockConsole.Outputs.Enqueue("n");
            StringReader _stringReader = new StringReader(_stringBuilder.ToString());
            Console.SetIn(_stringReader);

            program.RunCalculator();
            var expectedResult = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "This operation will result in a mathematical error." +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedResult, Regex.Replace(mockConsole.Inputs.ToString(), @"[\r\t\n]+", string.Empty));

        }

        [Fact]
        public void ShouldRunAndReturnResultOfAddingWithMockConsole()
        {
            MockConsole mockConsole = new MockConsole();
            Program program = new Program();
            program.MyConsole = mockConsole;
            StringWriter _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);

            StringBuilder _stringBuilder = new StringBuilder();
            StringReader _stringReader = new StringReader(_stringBuilder.ToString());
            Console.SetIn(_stringReader);
            mockConsole.Outputs.Enqueue("!");
            mockConsole.Outputs.Enqueue("4");
            mockConsole.Outputs.Enqueue("(");
            mockConsole.Outputs.Enqueue("5");
            mockConsole.Outputs.Enqueue("a");
            mockConsole.Outputs.Enqueue("n");
            program.RunCalculator();
            var expectedResult = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Type another number, and then press Enter: " +
                                 "This is not valid input. Please enter an integer value: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: 9" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedResult, Regex.Replace(mockConsole.Inputs.ToString(), @"[\r\t\n]+", string.Empty));
        }

    }
}
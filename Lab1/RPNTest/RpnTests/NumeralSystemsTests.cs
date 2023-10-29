using NUnit.Framework;
using System;

namespace RPNTest.RpnTests
{
    [TestFixture]
    public class NumeralSystemsTests
    {
        private const string EXCEPTION_MESSAGE_INVALID_ARGUMENT = "Unrecognized argument(s). One or more arguments are invalid or have not been implemented yet.";

        private RpnCalculator.Rpn _sut;
        
        [SetUp]
        public void Setup()
        {
            _sut = new RpnCalculator.Rpn();
        }

        [Test]
        [TestCase("-0xD1")]
        [TestCase("-0b0101")]
        public void given_invalid_number_throws_argument_exception(string input)
        {
            var expected = typeof(ArgumentException);

            Assert.Throws(expected, () => _sut.EvalRPN(input), EXCEPTION_MESSAGE_INVALID_ARGUMENT);
        }

        [Test]
        [TestCase("22")]
        [TestCase("-22")]
        [TestCase("0b0101")]
        [TestCase("0xD1")]
        public void given_valid_number_does_not_throw_argument_exception(string input)
        {
            Assert.DoesNotThrow(() => _sut.EvalRPN(input), EXCEPTION_MESSAGE_INVALID_ARGUMENT);
        }

        [Test]
        [TestCase("0xD1 0x02 +", 211)]
        [TestCase("0b001 0b100 +", 5)]
        public void calculate_sum(string input, int expected)
        {
            var value = _sut.EvalRPN(input);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void calculate_sum_of_values_written_in_different_numeral_systems()
        {
            var input = "0b001 4 +";
            var expected = 5;

            var value = _sut.EvalRPN(input);

            Assert.AreEqual(expected, value);
        }
    }
}

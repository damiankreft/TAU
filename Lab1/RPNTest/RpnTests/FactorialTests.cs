using NUnit.Framework;
using System;

namespace RPNTest.RpnTests
{
    [TestFixture]
    internal class FactorialTests
    {
        private RpnCalculator.Rpn _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new RpnCalculator.Rpn();
        }

        [Test]
        public void returns_correct_value_when_argument_is_valid()
        {
            var input = "5 !";
            var expected = 120;

            var value = _sut.EvalRPN(input);

            Assert.AreEqual(expected, value);
        }

        [Test]
        public void throws_an_exception_when_number_is_negative()
        {
            var input = "-5 !";
            var expected = typeof(InvalidOperationException);

            Assert.Throws(expected, () => _sut.EvalRPN(input));
        }

        [Test]
        public void given_0_value_returns_1()
        {
            var input = "0 !";
            var expected = 1;

            var value = _sut.EvalRPN(input);

            Assert.AreEqual(expected, value);
        }
    }
}

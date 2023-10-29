using NUnit.Framework;
using RPN;
using RpnCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNTest.RpnTests
{
    [TestFixture]
    public class NotationTests
    {
        private RpnCalculator.Rpn _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new RpnCalculator.Rpn();
        }

        [Test] 
        public void rpn_is_notation()
        {
            Assert.IsInstanceOf(typeof(INotation), _sut);
        }

        [Test]
        public void rpn_is_not_someNewRpn()
        {
            Assert.IsNull(_sut as SomeNewRpn);
        }
    }
}

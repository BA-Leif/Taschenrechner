using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject
{
    [TestClass]
    public class TestParser
    {
        [TestMethod]
        public void MultipleSubtraction()
        {
            string TestString = "5-5-5-5";
            double expected = -10;

            double actual = ParserClass.Start(TestString);

            Assert.AreEqual(expected, actual, 0.001);

        }

        [TestMethod]
        public void verschiedeneKlammerpaare()
        {
            string TestString = "(3+4)-(2-3)";
            double expected = 8;

            double actual = ParserClass.Start(TestString);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void MinusamAnfang()
        {
            string TestString = "-2+5";
            double expected = 3;

            double actual = ParserClass.Start(TestString);

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void VorzeichenNachDemRechenzeichen()
        {
            string TestString = "5+-2";
            double expected = 3;

            double actual = ParserClass.Start(TestString);

            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}

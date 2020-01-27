using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace UnitTestProject
{
    [TestClass]
    public class TestCalculator
    {
        [TestMethod]
        public void TestModulo()
        {
            //Angaben
            double x = 213;
            double y = 13;
            double operation = 1;
            double expected = 5;

            //Durchfürung
            double actual= CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "Modulo geht nicht.");
        }

        [TestMethod]
        public void TestDivisionBy0()
        {
            //Angaben
            double x = 2436.23;
            double operation = 5;

            double value = CalculationClass.ChooseOperation(x, 0, operation);

            Assert.AreEqual(value, Double.PositiveInfinity, "//0 = Unendlich");
            
        }

        [TestMethod]
        public void TestAddition()
        {
            //Angaben
            double x = 213;
            double y = 13;
            double operation = 6;
            double expected = x+y;

            //Durchfürung
            double actual = CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "Addition geht nicht.");
        }

        [TestMethod]
        public void TestSubtraction()
        {
            //Angaben
            double x = 213;
            double y = 13;
            double operation = 7;
            double expected = x-y;

            //Durchfürung
            double actual = CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "Subtraktion geht nicht.");
        }

        [TestMethod]
        public void TestPower()
        {
            //Angaben
            double x = 213;
            double y = 13;
            double operation = 2;
            double expected = Math.Pow(x,y);

            //Durchfürung
            double actual = CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "Exponential geht nicht.");
        }

        [TestMethod]
        public void TestHoch0()
        {
            //Angaben
            double x = 213;
            double y = 0;
            double operation = 2;
            double expected = 1;

            //Durchfürung
            double actual = CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "HochNull");
        }

        [TestMethod]
        public void TestRoot()
        {
            //Angaben
            double x = 213;
            double y = 13;
            double operation = 3;
            double expected = Math.Pow(x,(1/y));

            //Durchfürung
            double actual = CalculationClass.ChooseOperation(x, y, operation);

            //Überprüfung
            Assert.AreEqual(expected, actual, "Wurzel geht nicht.");
        }
    }
}

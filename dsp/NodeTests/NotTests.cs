using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using dsp.models;

namespace NodeTests
{
    [TestClass]
    public class NotTests
    {
        [TestMethod]
        public void TestNot_1()
        {
            // Arrange
            Not not = new Not() { NumberOfRequiredInputs = 1, InputValues = new List<int>() };
            not.InputValues.Add(1);

            // Act 
            not.tryCalculate();

            // Assert
            int result = not.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestNot_0()
        {
            // Arrange
            Not not = new Not() { NumberOfRequiredInputs = 1, InputValues = new List<int>() };
            not.InputValues.Add(0);

            // Act 
            not.tryCalculate();

            // Assert
            int result = not.Value;
            Assert.AreEqual(1, result, "Success!");
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dsp.models;

namespace NodeTests
{
    [TestClass]
    public class OrTests
    {
        [TestMethod]
        public void TestOr_1_1()
        {
            // Arrange
            Or or = new Or() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            or.InputValues.Add(1);
            or.InputValues.Add(1);

            // Act 
            or.tryCalculate();

            // Assert
            int result = or.Value;
            Assert.AreEqual(1, result, "Success!");
        }
        [TestMethod]
        public void TestOr_1_0()
        {
            // Arrange
            Or or = new Or() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            or.InputValues.Add(1);
            or.InputValues.Add(0);

            // Act 
            or.tryCalculate();

            // Assert
            int result = or.Value;
            Assert.AreEqual(1, result, "Success!");
        }
        [TestMethod]
        public void TestOr_0_0()
        {
            // Arrange
            Or or = new Or() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            or.InputValues.Add(0);
            or.InputValues.Add(0);

            // Act 
            or.tryCalculate();

            // Assert
            int result = or.Value;
            Assert.AreEqual(0, result, "Success!");
        }
    }
}

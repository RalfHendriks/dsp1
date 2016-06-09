using System;
using dsp;
using dsp.models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NodeTests
{
    [TestClass]
    public class AndTests
    {
        [TestMethod]
        public void TestAnd_1_1()
        {
            // Arrange
            And and = new And() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            and.InputValues.Add(1);
            and.InputValues.Add(1);

            // Act 
            and.tryCalculate();

            // Assert
            int result = and.Value;
            Assert.AreEqual(1, result, "Success!");
        }

        [TestMethod]
        public void TestAnd_1_0()
        {
            // Arrange
            And and = new And() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            and.InputValues.Add(1);
            and.InputValues.Add(0);

            // Act 
            and.tryCalculate();

            // Assert
            int result = and.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestAnd_0_0()
        {
            // Arrange
            And and = new And() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            and.InputValues.Add(0);
            and.InputValues.Add(0);

            // Act 
            and.tryCalculate();

            // Assert
            int result = and.Value;
            Assert.AreEqual(0, result, "Success!");
        }
    }
}

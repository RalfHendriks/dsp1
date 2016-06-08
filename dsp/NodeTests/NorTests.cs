using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dsp.models;
using System.Collections.Generic;

namespace NodeTests
{
    [TestClass]
    public class NorTests
    {
        [TestMethod]
        public void TestNor_1_1()
        {
            // Arrange
            Nor nor = new Nor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nor.InputValues.Add(1);
            nor.InputValues.Add(1);

            // Act 
            nor.tryCalculate();

            // Assert
            int result = nor.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestNor_1_0()
        {
            // Arrange
            Nor nor = new Nor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nor.InputValues.Add(1);
            nor.InputValues.Add(0);

            // Act 
            nor.tryCalculate();

            // Assert
            int result = nor.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestNor_0_0()
        {
            // Arrange
            Nor nor = new Nor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nor.InputValues.Add(0);
            nor.InputValues.Add(0);

            // Act 
            nor.tryCalculate();

            // Assert
            int result = nor.Value;
            Assert.AreEqual(1, result, "Success!");
        }
    }
}

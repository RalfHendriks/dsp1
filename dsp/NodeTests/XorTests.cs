using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dsp.models;
using System.Collections.Generic;

namespace NodeTests
{
    [TestClass]
    public class XorTests
    {
        [TestMethod]
        public void TestXor_1_1()
        {
            // Arrange
            Xor xor = new Xor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            xor.InputValues.Add(1);
            xor.InputValues.Add(1);

            // Act 
            xor.tryCalculate();

            // Assert
            int result = xor.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestXor_1_0()
        {
            // Arrange
            Xor xor = new Xor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            xor.InputValues.Add(1);
            xor.InputValues.Add(0);

            // Act 
            xor.tryCalculate();

            // Assert
            int result = xor.Value;
            Assert.AreEqual(1, result, "Success!");
        }
        [TestMethod]
        public void TestXor_0_0()
        {
            // Arrange
            Xor xor = new Xor() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            xor.InputValues.Add(0);
            xor.InputValues.Add(0);

            // Act 
            xor.tryCalculate();

            // Assert
            int result = xor.Value;
            Assert.AreEqual(0, result, "Success!");
        }
    }
}

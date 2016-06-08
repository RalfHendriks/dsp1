using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dsp.models;
using System.Collections.Generic;

namespace NodeTests
{
    [TestClass]
    public class NandTests
    {
        [TestMethod]
        public void TestNand_1_1()
        {
            // Arrange
            Nand nand = new Nand() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nand.InputValues.Add(1);
            nand.InputValues.Add(1);

            // Act 
            nand.tryCalculate();

            // Assert
            int result = nand.Value;
            Assert.AreEqual(0, result, "Success!");
        }
        [TestMethod]
        public void TestNand_1_0()
        {
            // Arrange
            Nand nand = new Nand() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nand.InputValues.Add(1);
            nand.InputValues.Add(0);

            // Act 
            nand.tryCalculate();

            // Assert
            int result = nand.Value;
            Assert.AreEqual(1, result, "Success!");
        }
        [TestMethod]
        public void TestNand_0_0()
        {
            // Arrange
            Nand nand = new Nand() { NumberOfRequiredInputs = 2, InputValues = new List<int>() };
            nand.InputValues.Add(0);
            nand.InputValues.Add(0);

            // Act 
            nand.tryCalculate();

            // Assert
            int result = nand.Value;
            Assert.AreEqual(1, result, "Success!");
        }
    }
}

using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class XorGateTest
    {
        InputHigh HighStartPoint;
        InputLow LowStartPoint;

        [TestInitialize]
        public void Initialize()
        {
            HighStartPoint = new InputHigh();
            LowStartPoint = new InputLow();
        }

        [TestMethod]
        public void Result_EvenInputsTrue_ShouldReturnFalse()
        {
            // Arrange
            XorGate Gate = new XorGate();
            Gate.In = new INode[] { HighStartPoint, HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void Result_UnevenInputsTrue_ShouldReturnTrue()
        {
            // Arrange
            XorGate Gate = new XorGate();
            Gate.In = new INode[] { HighStartPoint, LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }
    }
}

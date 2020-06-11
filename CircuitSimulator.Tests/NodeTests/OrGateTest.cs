using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class OrGateTest
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
        public void Result_AllInputsFalse_ShouldReturnFalse()
        {
            // Arrange
            OrGate Gate = new OrGate();
            Gate.In = new INode[] { LowStartPoint, LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void Result_AllInputsTrue_ShouldReturnTrue()
        {
            // Arrange
            OrGate Gate = new OrGate();
            Gate.In = new INode[] { HighStartPoint, HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void Result_AtLeastOneInputTrue_ShouldReturnTrue()
        {
            // Arrange
            OrGate Gate = new OrGate();
            Gate.In = new INode[] { HighStartPoint, LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }
    }
}

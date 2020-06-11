using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class NorGateTest
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
        public void Result_AllInputsTrue_ShouldReturnFalse()
        {
            // Arrange
            NorGate Gate = new NorGate();
            Gate.In = new INode[] { HighStartPoint, HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void Result_AllInputsFalse_ShouldReturnTrue()
        {
            // Arrange
            NorGate Gate = new NorGate();
            Gate.In = new INode[] { LowStartPoint, LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void Result_AtLeastOneInputTrue_ShouldReturnFalse()
        {
            // Arrange
            NorGate Gate = new NorGate();
            Gate.In = new INode[] { LowStartPoint, HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }
    }
}

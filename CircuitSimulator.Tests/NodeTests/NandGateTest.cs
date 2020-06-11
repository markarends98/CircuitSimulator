using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class NandGateTest
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
            NandGate Gate = new NandGate();
            Gate.In = new INode[] { HighStartPoint, HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void Result_NotAllInputsTrue_ShouldReturnTrue()
        {
            // Arrange
            NandGate Gate = new NandGate();
            Gate.In = new INode[] { HighStartPoint, LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }
    }
}

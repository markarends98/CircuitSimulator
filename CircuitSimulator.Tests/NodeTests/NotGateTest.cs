using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class NotGateTest
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
        public void Result_InputIsTrue_ShouldReturnFalse()
        {
            // Arrange
            NotGate Gate = new NotGate();
            Gate.In = new INode[] { HighStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsFalse(output);
        }

        [TestMethod]
        public void Result_InputIsFalse_ShouldReturnTrue()
        {
            // Arrange
            NotGate Gate = new NotGate();
            Gate.In = new INode[] { LowStartPoint };

            // Act
            bool output = Gate.Result();

            // Assert
            Assert.IsTrue(output);
        }
    }
}

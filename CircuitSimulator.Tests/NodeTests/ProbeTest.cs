using System;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.NodeTests
{
    [TestClass]
    public class ProbeTest
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
        public void Result_InputIsTrue_ShouldReturnTrue()
        {
            // Arrange
            Probe Probe = new Probe();
            Probe.ConnectInput(HighStartPoint);

            // Act
            bool output = Probe.Result();

            // Assert
            Assert.IsTrue(output);
        }

        [TestMethod]
        public void Result_InputIsFalse_ShouldReturnFalse()
        {
            // Arrange
            Probe Probe = new Probe();
            Probe.ConnectInput(LowStartPoint);

            // Act
            bool output = Probe.Result();

            // Assert

        }
    }
}
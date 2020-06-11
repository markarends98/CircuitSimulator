using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class MaxInputsValidationTest
    {
        private List<NodeDefinition> _nodeDefinitions;

        [TestInitialize]
        public void Initialize()
        {
            _nodeDefinitions = new List<NodeDefinition>()
            {
                new NodeDefinition()
                {
                    Name = "A",
                    Type = "INPUT_HIGH",
                    Outputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "B",
                    Type = "INPUT_HIGH",
                    Outputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "NOT",
                    Inputs = { "A", "B" },
                    Outputs = { "Cout" }
                },
                new NodeDefinition()
                {
                    Name = "Cout",
                    Type = "PROBE",
                    Inputs = { "NODE1" }
                }
            };
        }

        [TestMethod]
        public void Validate_NodeExceedingMaxInput_ShouldReturnFalse()
        {
            // Arange
            MaxInputsValidation maxInputsValidation = new MaxInputsValidation(1);

            // Act
            bool result = maxInputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeConformingMaxInput_ShouldReturnTrue()
        {
            // Arange
            MaxInputsValidation maxInputsValidation = new MaxInputsValidation(2);

            // Act
            bool result = maxInputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

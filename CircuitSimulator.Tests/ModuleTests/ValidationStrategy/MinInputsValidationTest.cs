using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class MinInputsValidationTest
    {
        private List<NodeDefinition> _nodeDefinitions;

        [TestInitialize]
        public void Initialize()
        {
            _nodeDefinitions = new List<NodeDefinition>()
            {
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "AND",
                    Inputs = { "A", "B" },
                    Outputs = { "Cout" }
                }
            };
        }

        [TestMethod]
        public void Validate_NodeLessThanMinInput_ShouldReturnFalse()
        {
            // Arange
            MinInputsValidation minInputsValidation = new MinInputsValidation(3);

            // Act
            bool result = minInputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeConformingMaxInput_ShouldReturnTrue()
        {
            // Arange
            MinInputsValidation minInputsValidation = new MinInputsValidation(2);

            // Act
            bool result = minInputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

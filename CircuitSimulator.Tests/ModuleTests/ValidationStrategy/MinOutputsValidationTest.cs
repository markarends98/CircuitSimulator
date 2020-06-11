using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class MinOutputsValidationTest
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
                    Outputs = { "Cout", "S" }
                }
            };
        }

        [TestMethod]
        public void Validate_NodeExceedingMinOutput_ShouldReturnFalse()
        {
            // Arange
            MinOutputsValidation minOutputsValidation = new MinOutputsValidation(3);

            // Act
            bool result = minOutputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeConformingMinOutput_ShouldReturnTrue()
        {
            // Arange
            MinOutputsValidation minOutputsValidation = new MinOutputsValidation(2);

            // Act
            bool result = minOutputsValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class DuplicateGateValidationTest
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
                    Type = "AND",
                    Inputs = { "A", "B" },
                    Outputs = { "Cout" }
                },
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "AND",
                    Inputs = { "A", "B" },
                    Outputs = { "S" }
                },
                new NodeDefinition()
                {
                    Name = "Cout",
                    Type = "PROBE",
                    Inputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "S",
                    Type = "PROBE",
                    Inputs = { "NODE1" }
                }
            };
        }

        [TestMethod]
        public void Validate_NodeWithDuplicateName_ShouldReturnFalse()
        {
            // Arange
            DuplicateGateValidation duplicateGateValidation = new DuplicateGateValidation();

            // Act
            bool result = duplicateGateValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeWithNonDuplicateName_ShouldReturnTrue()
        {
            // Arange
            DuplicateGateValidation duplicateGateValidation = new DuplicateGateValidation();
            _nodeDefinitions.Remove(_nodeDefinitions.FirstOrDefault(node => node.Name == "NODE1"));

            // Act
            bool result = duplicateGateValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

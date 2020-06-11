using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class LoopValidationTest
    {
        private List<NodeDefinition> _nodeDefinitions;

        [TestInitialize]
        public void Initialize()
        {
            _nodeDefinitions = new List<NodeDefinition>()
            {
                new NodeDefinition()
                {
                    Name = "S",
                    Type = "INPUT_HIGH",
                    Outputs = { "NODE5", "NODE6" }
                },
                new NodeDefinition()
                {
                    Name = "R",
                    Type = "INPUT_LOW",
                    Outputs = { "NODE5", "NODE6" }
                },
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "OR",
                    Inputs = { "NODE4", "NODE5" },
                    Outputs = { "NODE3" }
                },
                new NodeDefinition()
                {
                    Name = "NODE2",
                    Type = "OR",
                    Inputs = { "NODE6" },
                    Outputs = { "NODE4" }
                },
                new NodeDefinition()
                {
                    Name = "NODE3",
                    Type = "NOT",
                    Inputs = { "NODE1" },
                    Outputs = { "NODE2", "Q" }
                },
                new NodeDefinition()
                {
                    Name = "NODE4",
                    Type = "NOT",
                    Inputs = { "NODE2" },
                    Outputs = { "NODE1", "NQ" }
                },
                new NodeDefinition()
                {
                    Name = "NODE5",
                    Type = "AND",
                    Inputs = { "S", "R" },
                    Outputs = { "NODE1" }
                },
                new NodeDefinition()
                {
                    Name = "NODE6",
                    Type = "AND",
                    Inputs = { "S", "R" },
                    Outputs = { "NODE2" }
                },
                new NodeDefinition()
                {
                    Name = "Q",
                    Type = "PROBE",
                    Inputs = { "NODE3" }
                },
                new NodeDefinition()
                {
                    Name = "NQ",
                    Type = "PROBE",
                    Inputs = { "NODE4" }
                }
            };
        }

        [TestMethod]
        public void Validate_ContainsInfiniteLoop_ShouldReturnFalse()
        {
            // Arrange
            LoopValidation loopValidation = new LoopValidation();

            // Act
            bool result = loopValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

using System;
using System.Collections.Generic;
using CircuitSimulator.Domain.Models;
using CircuitSimulator.Factories;
using CircuitSimulator.ValidationStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CircuitSimulator.Tests.ModuleTests.ValidationStrategy
{
    [TestClass]
    public class ValidGatesValidationTest
    {
        private List<NodeDefinition> _nodeDefinitions;

        [TestInitialize]
        public void Initialize()
        {
            _nodeDefinitions = new List<NodeDefinition>();
        }

        [TestMethod]
        public void Validate_NodeWithInvalidType_ShouldReturnFalse()
        {
            // Arange
            ValidGatesValidation validGatesValidation = new ValidGatesValidation();
            _nodeDefinitions.Add(
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "ANDS"
                }
                );

            // Act
            bool result = validGatesValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeWithoutNameOrType_ShouldReturnFalse()
        {
            // Arange
            ValidGatesValidation validGatesValidation = new ValidGatesValidation();
            _nodeDefinitions.Add(new NodeDefinition());

            // Act
            bool result = validGatesValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Validate_NodeWithNameAndValidType_ShouldReturnTrue()
        {
            // Arange
            ValidGatesValidation validGatesValidation = new ValidGatesValidation();
            _nodeDefinitions.Add(
                new NodeDefinition()
                {
                    Name = "NODE1",
                    Type = "AND"
                }
                );

            // Act
            bool result = validGatesValidation.Validate(_nodeDefinitions);

            // Assert
            Assert.IsTrue(result);
        }
    }
}

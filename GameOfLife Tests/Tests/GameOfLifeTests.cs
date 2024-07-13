using GameOfLife_Kata;
using FluentAssertions;
using GameOfLife_Tests.TestData;
using System;

namespace GameOfLife_Tests.Tests
{
    public class Tests
    {
        [TestCaseSource(typeof(LifeGridExamples), nameof(LifeGridExamples.YieldLifeGridExamples))]
        public void CalculateNextGeneration_ReturnsCorrectNextGeneration(bool[,] inputLifeGrid, bool[,] resultLifeGrid)
        {
            //Arrange
            var gameInstance = new GameOfLife(inputLifeGrid);

            //Act
            gameInstance.CalculateNextGeneration();

            //Assert
            gameInstance.LifeGrid.Should().BeEquivalentTo(resultLifeGrid);
        }

        [TestCase(-1,-1)]
        [TestCase(2,2)]
        [TestCase(3,2)]
        [TestCase(2,3)]
        [TestCase(3,3)]
        public void CalculateNextGeneration_WithInvalidInputGridLengthWidth_ThrowsArgumentNullException(int gridLength, int gridWidth)
        {
            //Act
            var initializationAction = () => new GameOfLife(null);

            //Assert
            initializationAction.Should().Throw<ArgumentException>();
        }

        [Test]
        public void CalculateNextGeneration_WithNullInputGrid_ThrowsArgumentNullException()
        {
            //Act
            var initializationAction = () => new GameOfLife(null);

            //Assert
            initializationAction.Should().Throw<ArgumentNullException>();
        }
    }
}
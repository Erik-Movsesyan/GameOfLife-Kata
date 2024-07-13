using GameOfLife_Kata;
using FluentAssertions;
using GameOfLife_Tests.TestData;

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
    }
}
using System.Collections.Generic;

namespace GameOfLife_Tests.TestData
{
    public static class LifeGridExamples
    {
        public static IEnumerable<TestCaseData> YieldLifeGridExamples()
        {
            yield return new TestCaseData(
                new[,]
                {
                    {false, true, false },
                    {true, true, false },
                    {false, false, false }
                }, 
                new[,]
                {
                    {true, true, false },
                    {true, true, false },
                    {false, false, false }
                })
                .SetName("CalculateNextGeneration_3By3GridWithReverseLShapedLiveCells_ReturnsCorrectNextGeneration");
            yield return new TestCaseData(
                    new[,]
                    {
                        {false, true, false },
                        {false, true, false },
                        {false, true, false }
                    },
                    new[,]
                    {
                        {true, false, false },
                        {true, true, true },
                        {false, false, false }
                    })
                .SetName("CalculateNextGeneration_3By3GridWithIShapedLiveCells_ReturnsCorrectNextGeneration");
            yield return new TestCaseData(
                    new[,]
                    {
                        {false, false, false, false, false },
                        {false, true, false, true, false },
                        {false, true, false, true, false },
                        {false, true, true, true, false },
                        {false, false, false, false, false }
                    },
                    new[,]
                    {
                        {false, false, false, false, false },
                        {false, false, false, false, false },
                        {true, true, false, true, true },
                        {false, true, false, true, false },
                        {false, false, true, false, false }
                    })
                .SetName("CalculateNextGeneration_5By5GridWithUShapedLiveCells_ReturnsCorrectNextGeneration");

        }

    }
}

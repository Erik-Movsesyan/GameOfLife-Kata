using System;
using System.Drawing;

namespace GameOfLife_Kata
{
    public class GameOfLife
    {
        private readonly Point _gridDimensions;
        private bool[,] OldGenGrid { get; }
        public bool[,] LifeGrid { get; init; }

        public GameOfLife(bool[,] startingLifeGrid)
        {
            ValidateLifeGridDimensions(startingLifeGrid);

            LifeGrid = startingLifeGrid;
            _gridDimensions = new Point(LifeGrid.GetLength(0), LifeGrid.GetLength(1));

            OldGenGrid = new bool[_gridDimensions.X, _gridDimensions.Y];
            Array.Copy(LifeGrid, OldGenGrid, LifeGrid.Length);
        }

        public void CalculateNextGeneration()
        {
            for(int x = 0; x < _gridDimensions.X; x++)
            {
                for (int y = 0; y < _gridDimensions.Y; y++)
                {
                    InternalCalculateNextGeneration(x, y);
                }
                Console.WriteLine();
            }
        }

        private void InternalCalculateNextGeneration(int xPoint, int yPoint)
        {
            var liveNeighborsCount = GetLiveNeighborsCount(xPoint, yPoint);
            if (OldGenGrid[xPoint, yPoint])
            {
                if (!IsEligibleToStayLive(liveNeighborsCount))
                    LifeGrid[xPoint, yPoint] = false;
            }
            else
            {
                if (IsEligibleToBecomeLive(liveNeighborsCount))
                    LifeGrid[xPoint, yPoint] = true;
            }
        }

        private bool IsWithinGridLimits(int xPoint, int yPoint)
        {
            if (xPoint < 0 || yPoint < 0)
                return false;

            return xPoint < _gridDimensions.X && yPoint < _gridDimensions.Y;
        }

        private int GetLiveNeighborsCount(int xPoint, int yPoint)
        {
            var liveNeighborsCount = 0;

            for (int x = xPoint - 1; x <= xPoint + 1; x++)
            {
                for (int y = yPoint - 1; y <= yPoint + 1; y++)
                {
                    if (!IsWithinGridLimits(x, y) || (x == xPoint && y == yPoint))
                        continue;

                    if(OldGenGrid[x, y])
                        liveNeighborsCount++;
                }
            }

            return liveNeighborsCount;
        }

        private static bool IsEligibleToStayLive(int neighborsCount)
        {
            return neighborsCount is 2 or 3;
        }

        private static bool IsEligibleToBecomeLive(int neighborsCount)
        {
            return neighborsCount is 3;
        }

        private static void ValidateLifeGridDimensions(bool[,] startingLifeGrid)
        {
            ArgumentNullException.ThrowIfNull(startingLifeGrid);

            const int lifeGridMinimumDimension = 3;
            if (startingLifeGrid.GetLength(0) < lifeGridMinimumDimension || startingLifeGrid.GetLength(1) < lifeGridMinimumDimension)
                throw new ArgumentException("Each dimension of the Life Grid cannot be less than 3");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Business
{
    internal class GameBoard
    {
        private CellState[,] grid = new CellState[3, 3];

        public IEnumerable<CellState> Cells => grid.Cast<CellState>();

        public bool IsFull { get; private set; }

        public void Set(int x, int y, CellState cellState)
        {
            if (grid[y, x] != CellState.Empty)
                throw new Exception("Cell is already ocupied.");

            grid[y, x] = cellState;

            IsFull = Cells.All(z => z != CellState.Empty);
        }

        public void Reset()
        {
            grid = new CellState[3, 3];
        }

        public IEnumerable<CellState> GetRow(int i)
        {
            yield return grid[i, 0];
            yield return grid[i, 1];
            yield return grid[i, 2];
        }

        public IEnumerable<CellState> GetColumn(int i)
        {
            yield return grid[0, i];
            yield return grid[1, i];
            yield return grid[2, i];
        }

        public IEnumerable<CellState> GetFirstDiagonal()
        {
            yield return grid[0, 0];
            yield return grid[1, 1];
            yield return grid[2, 2];
        }

        public IEnumerable<CellState> GetSecondDiagonal()
        {
            yield return grid[2, 0];
            yield return grid[1, 1];
            yield return grid[0, 2];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    sb.Append(grid[j, i] + " ");

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
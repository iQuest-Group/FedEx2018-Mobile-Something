using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Business
{
    internal class GameBoard
    {
        private CellState[,] grid = new CellState[3, 3];

        public IEnumerable<CellState> Cells => grid.Cast<CellState>();

        public bool IsFull { get; private set; }

        public void Set(int x, int y, CellState cellState)
        {
            if (grid[x, y] != CellState.Empty)
                throw new Exception("Cell is already ocupied.");

            grid[x, y] = cellState;

            IsFull = Cells.All(z => z != CellState.Empty);
        }

        public void Reset()
        {
            grid = new CellState[3, 3];
        }

        public CellState? IsColumnOfSameState(int x)
        {
            bool isSame = grid[x, 0] == grid[x, 1] && grid[x, 0] == grid[x, 2];

            if (isSame)
                return grid[x, 0];
            return null;
        }

        public CellState? IsRowOfSameState(int y)
        {
            bool isSame = grid[0, y] == grid[1, y] && grid[0, y] == grid[2, y];

            if (isSame)
                return grid[0, y];

            return null;
        }
    }
}
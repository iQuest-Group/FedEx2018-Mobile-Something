using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Business
{
    internal class GameBoard
    {
        private CellState[,] grid = new CellState[3, 3];

        public IEnumerable<CellState> Cells => grid.Cast<CellState>();

        public void Set(int x, int y, CellState cellState)
        {
            if (grid[x, y] != CellState.Empty)
                throw new Exception("Cell is already ocupied.");

            grid[x, y] = cellState;
        }

        public void Reset()
        {
            grid = new CellState[3,3];
        }
    }
}
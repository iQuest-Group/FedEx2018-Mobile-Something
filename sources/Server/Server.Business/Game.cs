using System;
using System.Collections.Generic;

namespace Server.Business
{
    public class Game
    {
        private Player player1;
        private Player player2;

        private readonly GameBoard gameBoard = new GameBoard();

        public IEnumerable<CellState> Cells => gameBoard.Cells;

        public GameState State { get; private set; }

        public Player NextPlayer { get; set; }

        public void Start()
        {
            player1 = null;
            player2 = null;

            State = GameState.New;
            NextPlayer = null;
        }

        public void Register(Player player)
        {
            if (State != GameState.New)
                throw new Exception("A game is already in progress.");

            if (player1 == null)
            {
                player1 = player;
                return;
            }

            if (player2 == null)
            {
                player2 = player;
                NextPlayer = player1;
                State = GameState.InProgress;
                return;
            }

            throw new Exception("There are already two players in the game.");
        }

        public void Move()
        {

        }

        public void Listen()
        {

        }
    }
}
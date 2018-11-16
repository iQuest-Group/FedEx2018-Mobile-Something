using System;
using System.Collections.Generic;

namespace Server.Business
{
    public class Game
    {
        private readonly GameBoard gameBoard = new GameBoard();

        public Player Player1 { get; private set; }

        public Player Player2 { get; private set; }

        public IEnumerable<CellState> Cells => gameBoard.Cells;

        public GameState State { get; private set; }

        public Player NextPlayer { get; set; }

        public void Reset()
        {
            Player1 = null;
            Player2 = null;

            State = GameState.New;
            NextPlayer = null;
        }

        public void Register(Player player)
        {
            if (State != GameState.New)
                throw new Exception("A game is already in progress.");

            if (Player1 == null)
            {
                Player1 = player;
                return;
            }

            if (Player2 == null)
            {
                Player2 = player;
                NextPlayer = Player1;
                State = GameState.InProgress;
                return;
            }

            throw new Exception("There are already two players in the game.");
        }

        public void Move(Guid playerId, int x, int y)
        {
            if (State != GameState.InProgress)
                throw new Exception("The game is not started.");

            if (NextPlayer?.Id != playerId)
                throw new ArgumentException($"It's player's {NextPlayer.Name} turn. Player id: {NextPlayer.Id}.", nameof(playerId));

            if (x < 0 || x > 2)
                throw new ArgumentException($"Invlid position: [{x},{y}]", nameof(x));

            if (y < 0 || y > 2)
                throw new ArgumentException($"Invlid position: [{x},{y}]", nameof(y));

            if (playerId == Player1.Id)
            {
                gameBoard.Set(x, y, CellState.X);
                NextPlayer = Player2;
            }
            else if (playerId == Player2.Id)
            {
                gameBoard.Set(x, y, CellState.O);
                NextPlayer = Player1;
            }
            else
                throw new ArgumentException("Invlid player id.", nameof(playerId));
        }
    }
}
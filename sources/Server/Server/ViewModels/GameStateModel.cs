using System;
using System.Linq;
using Server.Business;

namespace Server.ViewModels
{
    internal class GameStateModel
    {
        public string Board { get; set; }

        public int GameState { get; set; }

        public Guid? NextPlayer { get; set; }

        public Guid? Winner { get; set; }

        public GameStateModel(Game game)
        {
            Board = string.Join(",", game.Cells.Cast<int>());
            GameState = (int)game.State;
            NextPlayer = game.NextPlayer?.Id;
            Winner = game.Winner?.Id;
        }
    }
}
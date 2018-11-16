using System.Linq;
using Server.Business;

namespace Server.ViewModels
{
    internal class GameStateModel
    {
        public string Board { get; set; }

        public int GameState { get; set; }

        public string NextPlayer { get; set; }

        public GameStateModel(Game game)
        {
            Board = string.Join(",", game.Cells.Cast<int>());
            GameState = (int)game.State;
            NextPlayer = game.NextPlayer?.Id.ToString("N");
        }
    }
}
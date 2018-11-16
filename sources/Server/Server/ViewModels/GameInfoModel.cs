using System.Linq;
using Server.Business;

namespace Server.ViewModels
{
    internal class GameInfoModel
    {
        public string Board { get; set; }

        public int GameState { get; set; }

        public Player Player1 { get; set; }

        public Player Player2 { get; set; }
        

        public string NextPlayer { get; set; }

        public GameInfoModel(Game game)
        {
            Board = string.Join(",", game.Cells.Cast<int>());
            GameState = (int)game.State;
            Player1 = game.Player1;
            Player2 = game.Player2;
            NextPlayer = game.NextPlayer?.Id.ToString("N");
        }
    }
}
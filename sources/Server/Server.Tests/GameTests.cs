using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server.Business;

namespace Server.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void WinByRow()
        {
            Game game = new Game();

            Player player1 = new Player { Name = "alez" };
            Player player2 = new Player { Name = "bogdan" };

            game.Register(player1);
            game.Register(player2);

            game.Move(player1.Id, 0, 0);
            game.Move(player2.Id, 0, 2);

            game.Move(player1.Id, 1, 0);
            game.Move(player2.Id, 1, 2);

            game.Move(player1.Id, 2, 0);

            Assert.AreEqual(GameState.Finished, game.State);
            Assert.AreSame(player1, game.Winner);

            Trace.WriteLine(game);
        }

        [TestMethod]
        public void WinByDiagonal()
        {
            Game game = new Game();

            Player player1 = new Player { Name = "alez" };
            Player player2 = new Player { Name = "bogdan" };

            game.Register(player1);
            game.Register(player2);

            game.Move(player1.Id, 0, 0);
            game.Move(player2.Id, 0, 2);

            game.Move(player1.Id, 1, 1);
            game.Move(player2.Id, 1, 2);

            game.Move(player1.Id, 2, 2);

            Assert.AreEqual(GameState.Finished, game.State);
            Assert.AreSame(player1, game.Winner);

            Trace.WriteLine(game);
        }
    }
}

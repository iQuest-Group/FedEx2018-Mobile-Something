// // Lisimba
// // Copyright (C) 2007-2016 Dust in the Wind
// // 
// // This program is free software: you can redistribute it and/or modify
// // it under the terms of the GNU General Public License as published by
// // the Free Software Foundation, either version 3 of the License, or
// // (at your option) any later version.
// // 
// // This program is distributed in the hope that it will be useful,
// // but WITHOUT ANY WARRANTY; without even the implied warranty of
// // MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// // GNU General Public License for more details.
// // 
// // You should have received a copy of the GNU General Public License
// // along with this program.  If not, see <http://www.gnu.org/licenses/>.

using Microsoft.AspNetCore.Mvc;
using Server.Business;
using Server.ViewModels;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {
        private static readonly Game Game;

        static GameController()
        {
            Game = new Game();
        }

        // GET
        [HttpGet]
        public JsonResult Index()
        {
            GameStateModel gameStateModel = new GameStateModel(Game);
            return Json(gameStateModel);
        }

        // GET
        [HttpGet]
        [Route("state")]
        public JsonResult State()
        {
            GameStateModel gameStateModel = new GameStateModel(Game);
            return Json(gameStateModel);
        }

        [HttpPost]
        [Route("register")]
        public JsonResult Register([FromBody] PlayerRegistrationModel playerRegistrationModel)
        {
            Player player = new Player
            {
                Name = playerRegistrationModel.Name
            };

            Game.Register(player);

            return Json(player.Id);
        }

        [HttpPost]
        [Route("move")]
        public JsonResult Move([FromBody] PlayerMoveModel playerMoveModel)
        {
            Game.Move(playerMoveModel.PlayerId, playerMoveModel.X, playerMoveModel.Y);

            GameStateModel gameStateModel = new GameStateModel(Game);
            return Json(gameStateModel);
        }
    }
}
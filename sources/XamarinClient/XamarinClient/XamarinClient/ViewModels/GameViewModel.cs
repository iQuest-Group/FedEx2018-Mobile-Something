using System;
using System.Collections.Generic;
using System.Text;
using XamarinClient.Models;

namespace XamarinClient.ViewModels
{
    public class GameViewModel
    {
        public Game Game{ get; }

        public GameViewModel(User user)
        {
            Game = new Game(user);
        }
    }
}

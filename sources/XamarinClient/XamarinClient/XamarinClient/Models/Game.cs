using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinClient.Models
{
    public class Game : RaisePropertyChangeModel
    {
        public User User { get; }

        public Game(User user)
        {
            User = user;
        }
    }
}

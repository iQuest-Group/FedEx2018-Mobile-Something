using System;
using System.Collections.Generic;
using System.Text;
using XamarinClient.Models;

namespace XamarinClient.Dto
{
    public class GameStateDto
    {
        public string Board { get; set; }
        public GameState GameState { get; set; }
        public string NextPlayer { get; set; }
        public string Winner { get; set; }
    }
}

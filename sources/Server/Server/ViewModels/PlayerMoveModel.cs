using System;

namespace Server.ViewModels
{
    public class PlayerMoveModel
    {
        public Guid PlayerId { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
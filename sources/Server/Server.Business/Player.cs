using System;

namespace Server.Business
{
    public class Player
    {
        public Guid Id { get; }

        public string Name { get; set; }

        public Player()
        {
            Id = Guid.NewGuid();
        }
    }
}
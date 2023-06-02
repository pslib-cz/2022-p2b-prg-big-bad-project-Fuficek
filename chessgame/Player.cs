using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal class Player
    {
        public string Name { get; set; }
        public bool IsWhite { get; set; }

        public Player(string name, bool isWhite)
        {
            Name = name;
            IsWhite = isWhite;
        }
    }
}

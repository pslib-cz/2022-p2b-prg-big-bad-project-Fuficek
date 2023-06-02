using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    internal interface IMovable
    {
        bool IsValidMove(int newPosition);
    }
}

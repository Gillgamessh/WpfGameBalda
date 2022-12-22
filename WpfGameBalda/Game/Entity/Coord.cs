using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game.Entity
{
    internal class Coord
    {
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
		public bool Equals(Coord other)
        {
            return other.X == X && other.Y == Y;
        }
    }
}

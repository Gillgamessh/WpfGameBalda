using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game.Entity
{
    internal class Letter
    {
        public char LetterSymbol { get; set; }
        public Coord coord { get; set; }
		public override bool Equals(object obj)
        {
            var o = obj as Letter;
            return LetterSymbol == o.LetterSymbol && coord.Equals(o.coord);
        }
    }
}

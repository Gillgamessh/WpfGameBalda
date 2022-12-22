using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game.Entity
{
    internal class Word
    {
        private readonly List<Letter> letters = new List<Letter>();

        public Word()
        {

        }
 
		public Word(IEnumerable<Letter> word)
        {
            letters.AddRange(word);
        }
     
		public Word AppendLetter(Letter letter)
        {
            letters.Add(letter);
            return this;
        }
  
		public Word AppendLetter(char letter, int x, int y)
        {
            return AppendLetter(new Letter
            {
                //coord = new Coord { X = x, Y = y },
                LetterSymbol = letter
            });
        }

        public string GetWord()
        {
            return letters.Aggregate(string.Empty, (current, letter) => current + letter.LetterSymbol);
        }

        public Letter GetLetter(int x, int y)
        {
            return letters.SingleOrDefault(l => l.coord.X == x && l.coord.Y == y);
        }

        public Letter GetLetter(Coord coordinate)
        {
            return GetLetter(coordinate.X, coordinate.Y);
        }

        public IEnumerable<Letter> Letters { get { return letters; } }

        public Word ClearWorld()
        {
            letters.Clear();
            return this;
        }
    }
}

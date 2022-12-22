using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game.Entity
{
    internal class Player
    {
        public string Name { get; private set; }
        
		public List<string> solveWords = new List<string>();
        
		public Player(string name)
        {

            this.Name = name;
        }
		public int Points { get; set; }
		internal void AddSolveWord(string word)
        {
            solveWords.Add(word);
        }
		public IEnumerable<string> SolveWords { get { return solveWords; } }

    }
}

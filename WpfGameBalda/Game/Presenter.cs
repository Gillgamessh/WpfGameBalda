using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfGameBalda.Game.Entity;

namespace WpfGameBalda.Game
{
    internal class Presenter
    {
        private List<Letter> field = new List<Letter>();
        private readonly IGameWindow window;
        private readonly Dictionary wordDictionary = new Dictionary();
        private Player currentPlayer;
        private Player playerOne;
        private Player playerTwo;


        public Presenter(IGameWindow window)
        {
            this.window = window;
            window.CheckWord += window_CheckWord;
            window.AcceptWord += window_AcceptWord;

            StartGame();
        }
     
		private void window_AcceptWord(object sender, EventArgs e)
        {
            AcceptWord(window.GetCurrentWord());
        }
        
		private void window_CheckWord(object sender, EventArgs e)
        {
            CheckWord(window.GetCurrentWord());
        }
        
		private void StartGame()
        {
            playerOne = new Player("Player 1");
            playerTwo = new Player("Player 2");
            currentPlayer = playerOne;
            var word = wordDictionary.GetWord(5);
            int i = 0;
            
            foreach (var ch in word)
            {
                field.Add(new Letter
                {
                    coord = new Coord(i++, 2),
                    LetterSymbol = ch
                });
            }

            ShowWindow();
        }
       
		private void CheckWord(IEnumerable<Letter> word)
        {
            var newword = new Word(word);
            if (wordDictionary.CheckWord(newword.GetWord()))
            {
                EndStage(newword);
            }
            else
                window.ShowAcceptWord(newword.GetWord());
        }
         
       
		private void EndStage(Word newword)
        {
            currentPlayer.Points += newword.GetWord().Length;
            currentPlayer.AddSolveWord(newword.GetWord());
            field.AddRange(newword.Letters);
            ChangePlayer();
            ShowWindow();
        }

        private void ShowWindow()
        {
            window
                .ClearField()
                .ShowLetters(field)
                .ShowPlayers(playerOne, playerTwo);
        }
        
		private void ChangePlayer()
        {
            currentPlayer = currentPlayer == playerOne ? playerTwo : playerOne;
        }
        
		private void AcceptWord(IEnumerable<Letter> word)
        {
            var newword = new Word(word);
            wordDictionary.AddWord(newword.GetWord());
            EndStage(newword);
        }
    }
}

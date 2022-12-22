using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGameBalda.Game
{
    internal interface IGameWindow
    {
        IGameWindow ShowLetters(IEnumerable<Entity.Letter> letters);
        IGameWindow ClearField();
        event EventHandler<EventArgs> NewGame;
        event EventHandler<EventArgs> AcceptWord;
        event EventHandler<EventArgs> CheckWord;

        void ShowAcceptWord(string word);

        void ShowPlayers(Entity.Player playerOne, Entity.Player playerTwo);

        IEnumerable<Entity.Letter> GetCurrentWord();

    }
}

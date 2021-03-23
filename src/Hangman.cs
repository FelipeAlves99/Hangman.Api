using System;
using System.Linq;

namespace Jogo_Forca.Api
{
    public class Hangman
    {
        public Hangman(string word)
        {
            Word = new string(word.Select(c => c = '_').ToArray());
        }

        private void Validate()
        {
            throw new NotImplementedException();
        }

        public string Word { get; private set; }
        public int Try { get; private set; } = 7;
        public char Letter { get; private set; }
        public GameStatus Status { get; private set; } = GameStatus.Hold;

        public void TestLetter()
        {
            if (StaticValues.word.Contains(Letter))
            {
                foreach (char letterChar in StaticValues.word)
                    Word += letterChar == Letter ? Letter : "_";
            }
            else
                Try--;
        }

        public void CheckGameStatus()
        {
            if (Try == 0)
            {
                Status = GameStatus.Lose;
                Word = StaticValues.word;
            }
            else if (!Word.Contains("_"))
                Status = GameStatus.Won;
            else
                Status = GameStatus.Hold;
        }

        public enum GameStatus
        {
            Won,
            Hold,
            Lose
        }
    }
}

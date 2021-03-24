using System.Collections.Generic;
using System.Linq;

namespace Jogo_Forca.Api
{
    public class Hangman
    {
        public Hangman(string word, char letter = '\0')
        {
            Word = word;
            Try = StaticValues.tries.HasValue? StaticValues.tries.Value : 7;
            Letter = letter;
            Status = GameStatus.Hold;
            Validate();
        }

        private void Validate()
        {
            List<string> addError = new List<string>();

            if (Word.Length != StaticValues.word.Length)
                addError.Add("Palavra incompativel com o começo do jogo, sugiro reiniciar a partida");

            if(string.IsNullOrEmpty(Word))
                addError.Add("Faltando palavra do jogo");

            /*TODO: 
             - add number checking in word
             - add letter checking if is not a number or special char
            */
        }

        public string Word { get; private set; }
        public int Try { get; private set; }
        public char Letter { get; private set; }
        public GameStatus Status { get; private set; }

        public void HideWord()
            => Word = new string(Word.Select(c => c = '_').ToArray());

        public void TestLetter()
        {
            string newWord = StaticValues.newWord != ""? StaticValues.newWord : "";

            if (StaticValues.word.Contains(Letter))
            {                
                for (int i = 0; i < StaticValues.word.Length; i++)
                {                                    
                    if(StaticValues.word[i] == Letter)
                        newWord += Letter;

                    else if(Word[i] != '_')
                        newWord += StaticValues.word[i];

                    else
                        newWord += "_";
                }

                Word = newWord;
            }
            else
            {
                Try--;
                StaticValues.tries = Try;
            }
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

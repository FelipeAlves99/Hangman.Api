using System.Linq;
using Flunt.Notifications;

namespace Jogo_Forca.Api
{
    public class Hangman : Notifiable
    {
        public Hangman(char letter = '\0')
        {
            Word = StaticValues.word;
            Try = StaticValues.tries.HasValue ? StaticValues.tries.Value : 7;
            Letter = letter;
            Status = GameStatus.Hold;
        }

        public void Validate()
        {
            if (!char.IsLetter(Letter))
                AddNotification("Hangman.Letter", "A propriedade 'Letter' deve ser uma letra");
        }

        public string Word { get; private set; }
        public int Try { get; private set; }
        public char Letter { get; private set; }
        public GameStatus Status { get; private set; }

        public void HideWord()
            => Word = new string(Word.Select(c => c = '_').ToArray());

        public void TestLetter()
        {
            string newWord = "";

            if (StaticValues.word.Contains(Letter))
            {
                for (int i = 0; i < StaticValues.word.Length; i++)
                {
                    if (StaticValues.word[i] == Letter)
                        newWord += Letter;

                    else if (StaticValues.missingWord[i] != '_')
                        newWord += StaticValues.word[i];

                    else
                        newWord += "_";
                }

                Word = newWord;
                StaticValues.missingWord = newWord;
            }
            else
            {
                if(string.IsNullOrWhiteSpace(StaticValues.missingWord))
                    HideWord();
                else
                    Word = StaticValues.missingWord;
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
            else if (!StaticValues.missingWord.Contains("_"))
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

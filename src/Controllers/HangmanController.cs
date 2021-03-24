using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jogo_Forca.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HangmanController : ControllerBase
    {
        private static readonly string[] words = new[]
        {
            "abacate", "abacaxi", "açai", "acerola", "amora", "araticum", "bacaba", "banana", "biriba", "cacau"
        };

        private readonly ILogger<HangmanController> _logger;

        public HangmanController(ILogger<HangmanController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/start")]
        public IActionResult GetRandomWord()
        {
            try
            {
                var random = new Random();
                var word = words[random.Next(0, words.Length)];

                StaticValues.word = word;
                StaticValues.newWord = "";
                StaticValues.tries = 7;

                Hangman hangman = new Hangman(word);
                hangman.HideWord();

                return Ok(hangman);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("/test")]
        public IActionResult PatchWord([FromBody] Hangman hangman)
        {
            try
            {
                hangman.CheckGameStatus();

                if (hangman.Status == Hangman.GameStatus.Hold)
                    hangman.TestLetter();
                    
                hangman.CheckGameStatus();

                return Ok(hangman);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
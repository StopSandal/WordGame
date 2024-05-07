
using System.Diagnostics.Tracing;
using System.Timers;
using WordGame.Data;
using WordGame.Settings;
using Timer = System.Timers.Timer;

namespace WordGame.Game
{
    internal class Game
    {
        private Settings.Settings settings;
        private GameResultItem result;
        public Game()
        {
            settings = GameSettings.GetSettings();
            result = new GameResultItem();
        }
        public void Start() 
        {
            PreGameDisplay();
            Task timer = StartTimer(settings.GetGameTime());
            while (!timer.IsCompleted)
            {
                UserAction();
            }
        }
        private void PreGameDisplay()
        {
            Console.Clear();
            Console.WriteLine("Are you ready?");
            Console.WriteLine("Press any key to start");
            Console.ReadKey();
        }
        private void UserAction()
        {
            var word = GetWord();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Write this words");
            Console.WriteLine("----------------------------");
            Console.WriteLine(word);
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Press Enter to end typing");
            int currentLine = Console.CursorTop;
            var userInput = Console.ReadLine();

            Console.SetCursorPosition(0, currentLine); // cleaning up all code lines below
            for (int i = currentLine + 1; i < Console.WindowHeight; i++) 
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

            if (userInput == word) 
            {
                result.Score += settings.GetWordCount();
            }

        }
        private void EndGame()
        {

        }
        private async Task StartTimer(int startTime)
        {
            int currentTime = startTime;
            while (currentTime > 0)
            {
                var position = Console.GetCursorPosition();
                Console.SetCursorPosition(0,0);
                Console.Write($"Time Left: {currentTime}");
                Console.SetCursorPosition(position.Left,position.Top);
                await Task.Delay(1000);
                currentTime--;
            }
        }
        private string GetWord()
        {
            return "sadasd";
        }
    }
}

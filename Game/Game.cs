using WordGame.Data;
using WordGame.FileImport;
using WordGame.InputReaders;
using WordGame.Settings;


namespace WordGame.Game
{
    internal sealed class Game
    {
        private Settings.Settings settings;
        private GameResultItem result;
        private IList<string> wordDictionary;
        public Game()
        {
            settings = GameSettings.GetSettings();
            result = new GameResultItem();
            wordDictionary = FileImportManager.GetWordDictionary(settings.GetDifficulty());
        }
        public void Start() 
        {
            PreGameDisplay();
            Task timer = StartTimer(5);
            timer.ContinueWith(t => { EndGame(); });
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
            var word = GetRandomWords(wordDictionary,settings.GetWordCount());
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("Write this words");
            Console.WriteLine("----------------------------");
            Console.WriteLine(word);
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine("Press Enter to end typing");
            int currentLine = Console.CursorTop;
            var userInput = Console.ReadLine();

            for (int i = currentLine; i < Console.WindowHeight; i++) // cleaning up all code lines below
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
            Console.Clear();
            Console.WriteLine("Game End");
            Console.WriteLine($"Total score: {result.Score}");
        }
        private async Task StartTimer(int startTime)
        {
            int currentTime = startTime;
            while (currentTime > 0)
            {
                var position = Console.GetCursorPosition();
                Console.SetCursorPosition(0,0);
                Console.Write($"Time Left: {currentTime:D2}");
                Console.SetCursorPosition(position.Left,position.Top);
                await Task.Delay(1000);
                currentTime--;
            }
        }
        public string GetRandomWords<T>(IList<T> list, int needed)
        {
            var random = new Random();
            for (int i = 0; i < needed; i++)
            {
                var index = random.Next(i, list.Count);
                var item = list[index];
                list[index] = list[i];
                list[i] = item;
            }

            return string.Join(" ",list.Take(needed));
        }
    }
}

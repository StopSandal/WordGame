using WordGame.Data;
using WordGame.FileImport;
using WordGame.InputReaders;
using WordGame.Menus;
using WordGame.Settings;


namespace WordGame.Game
{
    internal sealed class Game
    {
        private readonly Settings.Settings settings;
        public GameResultItem Result { get; }
        private readonly IList<string> wordDictionary;
        public Game()
        {
            settings = GameSettings.GetSettings();
            Result = new GameResultItem(settings.GetDifficulty());
            wordDictionary = FileImportManager.GetWordDictionary(settings.GetDifficulty());
        }
        public void Start() 
        {
            PreGameDisplay();
            Task timer = StartTimer(settings.GetGameTime());
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
            Console.WriteLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop-1);
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
                Result.Score += settings.GetWordCount();
            }

        }
        private void EndGame()
        {
            Console.Clear();
            Console.WriteLine("Time is up");
            Console.WriteLine($"Total score: {Result.Score}");
            Console.WriteLine("Press Enter to continue...");
        }
        private async Task StartTimer(int startTime)
        {
            int currentTime = startTime;
            while (currentTime > 0)
            {
                var (Left, Top) = Console.GetCursorPosition();
                Console.SetCursorPosition(0,0);
                Console.Write($"Time Left: {currentTime:D2}");
                Console.SetCursorPosition(Left,Top);
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
                (list[i], list[index]) = (list[index], list[i]);
            }

            return string.Join(" ",list.Take(needed));
        }
    }
}

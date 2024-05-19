using WordGame.Data;
using WordGame.FileImport;
using WordGame.InputReaders;
using WordGame.Menus;
using WordGame.Output;
using WordGame.Settings;


namespace WordGame.Game
{
    internal sealed class Game
    {
        private readonly IOutput output;
        private readonly Settings.Settings settings;
        public GameResultItem Result { get; }
        private readonly IList<string> wordDictionary;
        private int currentTime;
        public Game(IOutput output)
        {
            this.output=output;
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
            output.Clear();
            output.WriteLine("Are you ready?");
            output.WriteLine("Press Enter key to start");
            output.ReadLine();
        }
        private void UserAction()
        {
            var word = GetRandomWords(wordDictionary, settings.GetWordCount());
            WriteGameScreen(word);
            var userInput = output.ReadLine();

            if (userInput == word) 
            {
                Result.Score += settings.GetWordCount();
            }

        }
        private void EndGame()
        {
            Result.DateTime = DateTime.Now;
            output.Clear();
            output.WriteLine("Time is up");
            output.WriteLine($"Total score: {Result.Score}");
            output.WriteLine("Press Enter to continue...");
        }
        private async Task StartTimer(int startTime)
        {
            currentTime = startTime;
            while (currentTime > 0)
            {
                await OnTimerAction();
            }
        }
        private async Task OnTimerAction()
        {
            var (Left, Top) = output.GetCursorPosition();
            output.SetCursorPosition(0, 0);
            output.Write($"Time Left: {currentTime:D2}");
            output.SetCursorPosition(Left, Top);
            await Task.Delay(1000);
            currentTime--;
        }
        private string GetRandomWords<T>(IList<T> list, int needed)
        {
            var random = new Random();
            for (int i = 0; i < needed; i++)
            {
                var index = random.Next(i, list.Count);
                (list[i], list[index]) = (list[index], list[i]);
            }

            return string.Join(" ",list.Take(needed));
        }
        private void WriteGameScreen(string gameWord)
        {
            output.Clear();
            output.WriteLine($"Time Left: {currentTime:D2}");
            output.WriteLine("Write this words");
            output.WriteLine("----------------------------");
            output.WriteLine(gameWord);
            output.WriteLine("----------------------------");
            output.WriteLine();
            output.WriteLine("Press Enter to end typing");
        }
    }
}

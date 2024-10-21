using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WordGame;
using WordGame.Game;
using WordGame.Menus;
using WordGame.Output;

IServiceCollection services = new ServiceCollection();
ConfigureServices(services);
WordAppServiceProvider.SetServiceProvider(services.BuildServiceProvider());
var service = WordAppServiceProvider.GetServiceProvider().GetService<IRunnableApp>();
service.Run();


static void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IOutput,ConsoleOutput>();
    services.AddTransient<IRunnableApp,WordGameApp>();
    services.AddTransient<Game>();
    services.AddScoped<MainMenu>();
    services.AddScoped<GameMenu>();
    services.AddScoped<SettingsMenu>();
    services.AddScoped<FileImportMenu>();
    services.AddScoped<ResultsMenu>();
    services.AddScoped<ImportMenu>();
    services.AddScoped<ResultDifficultyMenu>();
    services.AddScoped<SetDifficultyMenu>();
    services.AddScoped<SetGameTimeMenu>();
    services.AddScoped<SetWordCountMenu>();
}
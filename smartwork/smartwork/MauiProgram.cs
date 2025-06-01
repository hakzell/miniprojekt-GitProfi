using CommunityToolkit;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using smartwork.ViewModels;
using smartwork.Data.Services;
using smartwork.Pages;
using Syncfusion.Maui.Core.Hosting;

namespace smartwork
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                   .UseMauiApp<App>()
                   .ConfigureSyncfusionCore()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

           

            builder.Services.AddSingleton<ManualPage>();
            builder.Services.AddSingleton <ManualViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            var path = FileSystem.AppDataDirectory;
            System.Diagnostics.Debug.WriteLine("Pfad: {0}" + path);
            string file = Path.Combine(path, "projects.xml");

            if (File.Exists(file))
            {
                System.Diagnostics.Debug.WriteLine("File exists");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("File does not exist");
            }


            builder.Services.AddSingleton<IRepository>(new Repository(file));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

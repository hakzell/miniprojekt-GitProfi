﻿using Microsoft.Extensions.Logging;
using smartwork.Core.ViewModels;
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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ExportPage>();
            builder.Services.AddSingleton<ExportViewModel>();
            builder.Services.AddSingleton<ManualPage>();
            builder.Services.AddSingleton<ManualViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

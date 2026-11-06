// Dupla: Luiz Felipe Gonçalves da Silva e Geovanna Barros de Assunção
// CBTPRDM - Trabalho Prático 03
using Microsoft.Extensions.Logging;
using Rastreio.Services;
using Rastreio.ViewModels;
using Rastreio.Views;

namespace Rastreio;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<RastreioService>();
        builder.Services.AddTransient<RastreioViewModel>();
        builder.Services.AddTransient<ResultadoViewModel>();
        builder.Services.AddTransient<RastreioPage>();
        builder.Services.AddTransient<ResultadoPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}

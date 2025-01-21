using ExamenProgreso3.Interfaces;
using ExamenProgreso3.Repositories;
using ExamenProgreso3.ViewModels;
using Microsoft.Extensions.Logging;

namespace ExamenProgreso3
{
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

            builder.Services.AddSingleton<IPaisRepositoy, PaisRepository>();
            builder.Services.AddTransient<PaginaConsultaViewModel>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

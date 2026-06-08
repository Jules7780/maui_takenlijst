using BL.Interfaces;
using BL.Services;
using DL;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TakenlijstApp.Services;
using TakenlijstApp.Viewmodels;

namespace TakenlijstApp
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
            builder.Services.AddSingleton<DatabankConnectie>();
            builder.Services.AddSingleton<ITaakRepo, TaakRepo>();
            builder.Services.AddSingleton<IPersoonRepo, PersoonRepo>();

            builder.Services.AddTransient<PersoonService>();
            builder.Services.AddTransient<PersonenLijstViewModel>();
            builder.Services.AddTransient<PersoonDetailViewModel>();

            builder.Services.AddTransient<NavigatieService>();
            builder.Services.AddTransient<MessageService>();

            builder.Services.AddTransient<TaakService>();
            builder.Services.AddTransient<TakenLijstViewModel>();
            builder.Services.AddTransient<TaakDetailViewModel>();




            Routing.RegisterRoute(nameof(PersoonDetailPagina), typeof(PersoonDetailPagina));
            Routing.RegisterRoute(nameof(PersonenLijstPagina), typeof(PersonenLijstPagina));
            Routing.RegisterRoute(nameof(TaakDetailPagina), typeof(TaakDetailPagina));
            //Routing.RegisterRoute(nameof(TakenLijstPagina), typeof(TakenLijstPagina));




#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

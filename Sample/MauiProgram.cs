using Microsoft.Extensions.Logging;

namespace Sample
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
                }).ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler(typeof(MagicGradients.Forms.GradientView), typeof(MagicGradients.Forms.GraphicsViewRenderer));


                }
                
               ); 

#if DEBUG
    		builder.Logging.AddDebug();
           
#endif

            return builder.Build();
        }
    }
}

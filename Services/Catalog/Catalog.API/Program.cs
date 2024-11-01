


namespace Catalog.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCarter();
            builder.Services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
                config.AddOpenBehavior(typeof(ValidationBehavior<,>)); 
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));

            });

            builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            builder.Services.AddMarten(options =>
            {
                options.Connection(builder.Configuration.GetConnectionString("Database")!);
            }).UseLightweightSessions();

            builder.Services.AddExceptionHandler<CustomExceptionHandler>();



            var app = builder.Build();
            app.MapCarter();

            app.UseExceptionHandler(options => { });


            app.Run();
        }
    }
}

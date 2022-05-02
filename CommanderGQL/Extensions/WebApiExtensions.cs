namespace CommanderGQL.Extensions
{
    public static class WebApiExtensions
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services)
        {
            services
                .AddControllers();

            return services;
        }

        public static WebApplication UseWebApi(this WebApplication app)
        {
            app
                .MapControllers();

            return app;
        }
    }
}
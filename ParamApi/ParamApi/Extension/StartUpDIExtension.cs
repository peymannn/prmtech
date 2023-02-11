using ParamApi.Data.Uow;

namespace ParamApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();
        }
    }
}

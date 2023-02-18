using AutoMapper;
using ParamApi.Data;
using ParamApi.Data.Model;
using ParamApi.Data.Repository.Abstract;
using ParamApi.Data.Repository.Concrete;
using ParamApi.Data.Uow;
using ParamApi.Service;
using ParamApi.Service.Abstract;
using ParamApi.Service.Concrete;

namespace ParamApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServicesDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();


            //services.AddScoped<IAccountRepository, AccountRepository>();
            //services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
            services.AddSingleton<SingletonService>();


            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}

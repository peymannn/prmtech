using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ParamApi.Data.Context;
using ParamApi.Data.Uow;
using ParamApi.Extension;

namespace ParamApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextDI(Configuration);
            services.AddServicesDI();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ParamApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ParamApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });




           app.Use((ctx, next) =>
           {
                // Get all the services and increase their counters...
               var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
               var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
               var transient = ctx.RequestServices.GetRequiredService<TransientService>();

               singleton.Counter++;
               scoped.Counter++;
               transient.Counter++;

               return next();
           });
           app.Run(async ctx =>
           {
                // ...then do it again...
               var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
               var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
               var transient = ctx.RequestServices.GetRequiredService<TransientService>();

               singleton.Counter++;
               scoped.Counter++;
               transient.Counter++;

                // ...and display the counter values.
               await ctx.Response.WriteAsync($"Singleton: {singleton.Counter}\n");
               await ctx.Response.WriteAsync($"Scoped: {scoped.Counter}\n");
               await ctx.Response.WriteAsync($"Transient: {transient.Counter}\n");
           });
        }
    }
}

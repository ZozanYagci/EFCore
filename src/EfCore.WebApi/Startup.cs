
using EfCore.Common;
using EfCore.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EfCore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging(conf =>
            {
                conf.AddConsole();
                conf.AddDebug();
            });

            services.AddDbContext<ApplicationDbContext>(conf =>
            {
                conf.UseSqlServer(StringConstants.DbConnectionString);
                conf.EnableSensitiveDataLogging();
                //conf.LogTo(Console.WriteLine);
                //conf.UseLoggerFactory(services)
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
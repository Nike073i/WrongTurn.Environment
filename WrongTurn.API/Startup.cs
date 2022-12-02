using Microsoft.EntityFrameworkCore;
using WrongTurn.API.Extensions;
using WrongTurn.Data.Context;
using WrongTurn.Data.Extensions;

namespace WrongTurn.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnection = Configuration.GetSection("Database").GetConnectionString("MSSQL");
            services.AddDbContext<WrongTurnDbContext>(options => options.UseSqlServer(dbConnection));
            services.AddControllers();
            services.AddRepositories();
            services.AddApiServices();
            services.AddSwaggerGen();
            services.AddSwaggerGenNewtonsoftSupport();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WrongTurnDbContext context)
        {
            if (env.IsDevelopment())
            {
                context.InsertDefaultValues().Wait();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

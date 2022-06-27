using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VideoGameTest.Application.Interface;
using VideoGameTest.Application.Models;
using VideoGameTest.Application.Services;
using VideoGameTest.DataAccess;
using VideoGameTest.DataAccess.Entities;
using VideoGameTest.DataAccess.Interfaces;
using VideoGameTest.DataAccess.Repository;

namespace VideoGameTest.WebApi
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
            //services.AddControllers(); // используем контроллеры без представлений

            //настройка соединения с бд
            services.AddDbContext<DbVideoGameTestContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))); //Строка соединения находится в .json


            services.AddControllers().AddJsonOptions(
            options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddCors();

            services.AddTransient<IGenericRepository<GameType>, GenericRepository<GameType>>();
            services.AddTransient<IGenericRepository<VideoGame>, GenericRepository<VideoGame>>();

            services.AddTransient<IVideoGameService, VideoGameService>();
            services.AddTransient<IGameTypeService, GameTypeService>();
            services.AddTransient<IAdminService, AdminService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();


            app.UseCors(builder => builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // подключаем маршрутизацию на контроллеры
            });
        }
    }
}


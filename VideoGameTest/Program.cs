using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using VideoGameTest.DataAccess;
using VideoGameTest.DataAccess.Extentions;

namespace VideoGameTest.WebApi
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            await CreateHostBuilder(args).Build()
                .MigrateDbContext<DbVideoGameTestContext>()      //Статический класс для синхронизации созданных миграций
                .RunAsync();
            return 0;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

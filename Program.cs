using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Se o ProductContext estiver em outra pasta, lembre-se de adicionar o "using" dele aqui em cima, ex: using ProductAPI.Context;

namespace ProductAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1. Primeiro, construímos a aplicação, mas não a iniciamos ainda.
            var host = CreateHostBuilder(args).Build();

            // 2. Abrimos um escopo para pegar a conexão do banco e rodar a Migration
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ProductContext>();
                if (string.Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), Environments.Development, StringComparison.OrdinalIgnoreCase))
                {
                    // Em desenvolvimento local, cria o banco SQLite automaticamente sem exigir SQL Server.
                    dbContext.Database.EnsureCreated();
                }
                else
                {
                    dbContext.Database.Migrate();
                }
            }

            // 3. Finalmente, rodamos a aplicação
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
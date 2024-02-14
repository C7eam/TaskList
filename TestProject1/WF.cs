using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using TaskList;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class WF : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // Удалим зарегистрированный DataContext
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));
                if (descriptor != null)
                    services.Remove(descriptor);

                // Зарегистрируем снова с указанием на тестовую БД
                services.AddDbContextPool<ApplicationContext>(opts => opts.UseNpgsql("Host=localhost;Database=testdb;Username=postgres;Password=;"));

                // Обеспечим создание БД
                var serviceProvider = services.BuildServiceProvider();
                using var scope = serviceProvider.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var context = scopedServices.GetRequiredService<ApplicationContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                // Здесь можно выполнить код "наполняющий" БД тестовыми данными...
            });
        }
    }
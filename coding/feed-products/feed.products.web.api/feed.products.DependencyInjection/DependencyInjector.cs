using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace feed.products.DependencyInjection
{
    public static class DependencyInjector
    {
        static IServiceProvider ServiceProvider { get; set; }

        static IServiceCollection Services { get; set; }

        public static void AddDbContext<T>(string connectionString) where T : DbContext
        {
            var loggerFactory = new LoggerFactory();
            

            //for sql server
            Services.AddDbContext<T>(options => options.UseSqlServer(connectionString).UseLoggerFactory(loggerFactory));

            //for mongo db
            
            Services.Configure<BookstoreDatabaseSettings>(
                Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
        }

        public static void CreateDatabase<T>() where T : DbContext
        {
            var context = GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }
        public static T GetService<T>()
        {
            Services = Services ?? RegisterServices();
            ServiceProvider = ServiceProvider ?? Services.BuildServiceProvider();
            return ServiceProvider.GetService<T>();
        }

        public static IServiceCollection RegisterServices()
        {
            return RegisterServices(new ServiceCollection());
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
           
            //Add your Services before this.
            Services = services;

            return Services;
        }
    }
}

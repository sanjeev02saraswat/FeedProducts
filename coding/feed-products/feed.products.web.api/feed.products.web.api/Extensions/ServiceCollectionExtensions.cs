using feed.products.Database.Context;
using feed.products.DependencyInjection;
using feed.products.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace feed.products.web.api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        static public void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            DependencyInjector.RegisterServices(services);
            DependencyInjector.AddDbContext<DatabaseContext>(Configuration.GetConnectionString(nameof(DataBaseContext)));


            //     services.Configure<IMongoConnectionString>(
            //Configuration.GetSection(nameof(MongoConnectionString)));

            //     services.AddSingleton<IMongoConnectionString>(sp =>
            //         sp.GetRequiredService<IOptions<MongoConnectionString>>().Value);
        }
     
    }


}

//using feed.products.Database.Context;
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
           

            //     services.Configure<BookstoreDatabaseSettings>(
            //Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

            //     services.AddSingleton<IBookstoreDatabaseSettings>(sp =>
            //         sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);
        }
        private static AppSettings RegisterAppSettingsServices()
        {
            AppSettings AppData = new AppSettings();
            string path = Environment.CurrentDirectory + "\\" + "appsettings.json";
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                var AppSettingData = reader.ReadToEnd();
                AppData = JsonConvert.DeserializeObject<AppSettings>(AppSettingData);
            }
            return AppData;
        }
    }


}

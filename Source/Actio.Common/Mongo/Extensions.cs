using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Actio.Common.Mongo
{
    public static class EXtensions
    {
        public static void AddMongoDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoOptions>(configuration.GetSection("mongo"));
            services.AddSingleton<MongoClient>(conf =>
            {
                var options = conf.GetService<IOptions<MongoOptions>>();

                return new MongoClient(options.Value.ConnectionString);
            });

            services.AddScoped<IMongoDatabase>(conf =>
            {
                var options = conf.GetService<IOptions<MongoOptions>>();
                var client = conf.GetService<MongoClient>();

                return client.GetDatabase(options.Value.Database);
            });
            services.AddScoped<IDatabaseInitializer, DatabaseInitializer>();
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        }
    }
}
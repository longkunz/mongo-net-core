using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDb.Core.Configuaration;
using MongoDb.Core.Repository;

namespace MongoDb.Core
{
    public static class MongoDbExtension
    {
        public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration, string configurationSection = "MongoDb")
        {

            services.Configure<MongoDbSetting>(configuration.GetSection(configurationSection));

            services.AddSingleton<IMongoDbSetting>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSetting>>().Value);

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }
    }
}

using LojaDoSeuManoel.Application.Interfaces.Logs;
using LojaDoSeuManoel.Infra.Data.MongoDB.Context;
using LojaDoSeuManoel.Infra.Data.MongoDB.Settings;
using LojaDoSeuManoel.Infra.Data.MongoDB.Storages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infra.Data.MongoDB.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDB (this IServiceCollection services, IConfiguration configuration)
        {

            //capturar as configurações do /appsettings
            var mongoDBSettings = new MongoDBSettings();
            new ConfigureFromConfigurationOptions<MongoDBSettings>
                (configuration.GetSection("MongoDBSettings"))
                .Configure(mongoDBSettings);

            //injeção de dependência
            services.AddSingleton(mongoDBSettings);
            services.AddScoped<MongoDBContext>();
            services.AddTransient<ILogPedidoDataStore, LogPedidoDataStore>();



            return services;
        }
    }

}

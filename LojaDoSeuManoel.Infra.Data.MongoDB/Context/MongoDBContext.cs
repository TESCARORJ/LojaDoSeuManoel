using LojaDoSeuManoel.Application.Models;
using LojaDoSeuManoel.Infra.Data.MongoDB.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LojaDoSeuManoel.Application.Models.LogPedidoModel;

namespace LojaDoSeuManoel.Infra.Data.MongoDB.Context
{
    /// <summary>
    /// Classe para conexão como o MongoDB e mapeamento das collections
    /// </summary>
    public class MongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;

        public MongoDBContext(MongoDBSettings mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings;

            #region Conexão com o banco de dados
            var settings = MongoClientSettings.FromUrl (new MongoUrl(_mongoDBSettings.Url));
            var client = new MongoClient(settings);

            _mongoDatabase = client.GetDatabase(_mongoDBSettings.Database);

            #endregion
        }

        public IMongoCollection<LogPedidoModel> LogPedidos=> _mongoDatabase.GetCollection<LogPedidoModel>("LogPedidos");
    }

}

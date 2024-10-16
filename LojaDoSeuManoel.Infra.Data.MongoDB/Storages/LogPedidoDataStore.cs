using LojaDoSeuManoel.Application.Interfaces.Logs;
using LojaDoSeuManoel.Application.Models;
using LojaDoSeuManoel.Infra.Data.MongoDB.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Infra.Data.MongoDB.Storages
{
    /// <summary>
    /// Implementação da interface da camada de aplicação
    /// para geração dos logs de pedidos no MongoDB
    /// </summary>
    public class LogPedidoDataStore : ILogPedidoDataStore
    {
        private readonly MongoDBContext _mongoDBContext;

        public LogPedidoDataStore(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task AddAsync(LogPedidoModel model)
        {
            await _mongoDBContext.LogPedidos.InsertOneAsync(model);
        }
    }

}

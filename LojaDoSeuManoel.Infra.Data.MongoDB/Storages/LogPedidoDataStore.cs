using LojaDoSeuManoel.Application.Interfaces.Logs;
using LojaDoSeuManoel.Application.Models;
using LojaDoSeuManoel.Infra.Data.MongoDB.Context;
using MongoDB.Driver;
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

        public async Task<List<LogPedidoModel>> GetAsync(long pedidoId, int pageNumber, int pageSize)
        {
            //definindo o filtro para consultar somente logs de um determinado pedido
            var filter = Builders<LogPedidoModel>.Filter.Eq(log => log.PedidoId, pedidoId);

            //construindo a consulta com a paginação
            var result = await _mongoDBContext.LogPedidos
                .Find(filter) //aplicando o filtro
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .SortByDescending(log => log.DataOperacao)
                .ToListAsync();

            return result;
        }

        public async Task<int> GetTotalCountAsync(long pedidoId)
        {
            //definindo o filtro para consultar somente logs de um determinado pedido
            var filter = Builders<LogPedidoModel>.Filter.Eq(log => log.PedidoId, pedidoId);

            return (int)await _mongoDBContext.LogPedidos.CountDocumentsAsync(filter);
        }
    }

}

using LojaDoSeuManoel.Application.Commands;
using LojaDoSeuManoel.Application.Interfaces.Logs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Handlers
{
    /// <summary>
    /// Classe para processar os COMMANDS de pedido disparados pelo MediatR
    /// </summary>
    public class PedidoRequestHandler : IRequestHandler<PedidoCommand>
    {
        private readonly ILogPedidoDataStore _logPedidoDataStore;
        public PedidoRequestHandler (ILogPedidoDataStore logPedidoDataStore)
        {
            _logPedidoDataStore = logPedidoDataStore;
        }
        
        public async Task Handle (PedidoCommand request, CancellationToken cancellationToken)
        {
            await _logPedidoDataStore.AddAsync(request.LogPedido);
        }
    }
}

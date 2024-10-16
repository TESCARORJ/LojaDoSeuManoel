using LojaDoSeuManoel.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Commands
{
    /// <summary>
    /// Representação de um "COMMAND" CQRS para pedido
    /// </summary>
    public class PedidoCommand : IRequest
    {
        /// <summary>
        /// Registro do log de operação com o pedido (Add, Update, Delete)
        /// </summary>
        public LogPedidoModel? LogPedido { get; set; }
    }
}

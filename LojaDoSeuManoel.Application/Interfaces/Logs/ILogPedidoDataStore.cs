using LojaDoSeuManoel.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Application.Interfaces.Logs
{
    public interface ILogPedidoDataStore
    {
        Task AddAsync(LogPedidoModel model);
    }
}

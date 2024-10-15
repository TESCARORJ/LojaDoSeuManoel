using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public interface IPedidoDomainService : IDisposable
    {
        Task<Pedido> AddAsync(Pedido pedido);
        Task<Pedido> UpdateAsync(Pedido pedido);
        Task<Pedido> DeleteAsync(long id);
        Task<Pedido> GetByIdAsync(long id);

    }
}

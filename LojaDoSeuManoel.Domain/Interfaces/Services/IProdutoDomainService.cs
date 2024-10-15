using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public interface IProdutoDomainService : IDisposable
    {
        Task<Produto> AddAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task<Produto> DeleteAsync(int id);
        Task<Produto> GetByIdAsync(int id);
       
    }
}

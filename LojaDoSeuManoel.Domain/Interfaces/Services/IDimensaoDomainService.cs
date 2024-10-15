using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public interface IDimensaoDomainService : IDisposable
    {
        Task<Dimensao> AddASync(Dimensao dimensao);
        Task<Dimensao> UpdateAsync(Dimensao dimensao);
        Task<Dimensao> DeleteAsync(int id);
        Task<Dimensao> GetByIdAsync(int id);
    }
}

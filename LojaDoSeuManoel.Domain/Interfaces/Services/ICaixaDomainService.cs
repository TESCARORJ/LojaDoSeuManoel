using LojaDoSeuManoel.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public interface ICaixaDomainService : IDisposable
    {
        //Task<Caixa> AddAsync(Caixa caixa);
        //Task<Caixa> UpdateAsync(Caixa caixa);
        //Task<Caixa> DeleteAsync(int id);
        //Task<Caixa> GetByIdAsync(int id);
        Task<List<Caixa>> GetAllAsync();
        Task<bool> VerificaDimensao(double altura, double largura, double comprimento);
        Task<Caixa?> GetCaixa(double altura, double largura, double comprimento);


    }
}

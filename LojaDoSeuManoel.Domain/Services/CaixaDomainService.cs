using FluentValidation;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Exceptions;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Services
{
    public class CaixaDomainService : ICaixaDomainService
    {
        private readonly ICaixaRepository _caixaRepository;
        private readonly IValidator<Caixa> _validator;

        public CaixaDomainService(ICaixaRepository caixaRepository, IValidator<Caixa> validator)
        {
            _caixaRepository = caixaRepository;
            _validator = validator;
        }

        //public async Task<Caixa> AddAsync(Caixa caixa)
        //{
        //    var validatorResult = await _validator.ValidateAsync(caixa);

        //    if (validatorResult.IsValid)
        //    {
        //        throw new ValidationException(validatorResult.Errors);
        //    }
        //    await _caixaRepository.AddAsync(caixa);
        //    return caixa;
        //}

        //public async Task<Caixa> UpdateAsync(Caixa caixa)
        //{

        //    if (caixa == null)
        //    {
        //        throw new Exception("Caixa inválido");
        //    }

        //    if (!await _caixaRepository.VerifyExistsAsync(x => x.Id == caixa.Id))
        //    {
        //        throw new CaixaNotFoundException(caixa.Id);
        //    }

        //    //if (_validator is CaixaValidator validator)
        //    //    validator.SetCurrentCaixaId(caixa.CaixaId);

        //    var validatorResult = await _validator.ValidateAsync(caixa);
        //    if (validatorResult.IsValid)
        //    {
        //        throw new ValidationException(validatorResult.Errors);
        //    }

        //    await _caixaRepository.UpdateAsync(caixa);
        //    return caixa;

        //}

        //public async Task<Caixa> DeleteAsync(int id)
        //{
        //    var caixa = await _caixaRepository.GetByIdAsync(id);
        //    if (caixa == null)
        //    {
        //        throw new CaixaNotFoundException(id);
        //    }

        //    await _caixaRepository.DeleteAsync(caixa);
        //    return caixa;
        //}

        //public Task<Caixa> GetByIdAsync(int id)
        //{
        //    return _caixaRepository.GetByIdAsync(id);
        //}

        public async Task<List<Caixa>> GetAllAsync()
        {
            var lista = await _caixaRepository.GetManyAsync(x => x.Id > 0);
            return lista;
        }

        public async Task<bool> VerificaDimensao(double altura, double largura, double comprimento)
        {
            var result = await _caixaRepository.GetManyAsync(x => x.Dimensao.Altura == altura && x.Dimensao.Largura == largura && x.Dimensao.Comprimento == comprimento);
            return result.Count > 0;
        }
        public async Task<Caixa?> GetCaixa(double altura, double largura, double comprimento)
        {
            var caixa = await _caixaRepository.GetOneAsync(x => x.Dimensao.Altura == altura && x.Dimensao.Largura == largura && x.Dimensao.Comprimento == comprimento);
          
            return caixa;
        }

        public void Dispose()
        {
            _caixaRepository.Dispose();
        }


    }
}

using FluentValidation;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Exceptions;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using LojaDoSeuManoel.Domain.Interfaces.Services;
using LojaDoSeuManoel.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Services
{
    public class DimensaoDomainService : IDimensaoDomainService
    {
        private readonly IDimensaoRepository _dimensaoRepository;
        private readonly IValidator<Dimensao> _validator;

        public DimensaoDomainService(IDimensaoRepository dimensaoRepository, IValidator<Dimensao> validator)
        {
            _dimensaoRepository = dimensaoRepository;
            _validator = validator;
        }

        public async Task<Dimensao> AddASync(Dimensao dimensao)
        {
            var validatorResult = await _validator.ValidateAsync(dimensao);

            if (validatorResult.IsValid) 
            {
                throw new ValidationException(validatorResult.Errors);
            }
            await _dimensaoRepository.AddAsync(dimensao);
            return dimensao;
        }

        public async Task<Dimensao> UpdateAsync(Dimensao dimensao)
        {
            if(!await _dimensaoRepository.VerifyExistsAsync(x => x.Id == dimensao.Id))
            {
                throw new DimensaoNotFoundException(dimensao.Id);
            }   

            if(_validator is DimensaoValidator validator)
                validator.SetCurrentDimensaoId(dimensao.Id);

            var validatorResult = await _validator.ValidateAsync(dimensao);
            if (validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            await _dimensaoRepository.UpdateAsync(dimensao);
            return dimensao;

        }

        public async Task<Dimensao> DeleteAsync(int id)
        {
            var dimensao = await _dimensaoRepository.GetByIdAsync(id);
            if (dimensao == null)
            {
                throw new DimensaoNotFoundException(id);
            }

            await _dimensaoRepository.DeleteAsync(dimensao);
            return dimensao;
        }

        public Task<Dimensao> GetByIdAsync(int id)
        {
            return _dimensaoRepository.GetByIdAsync(id);
        }

        public void Dispose()
        {
            _dimensaoRepository.Dispose();
        }

    }
}

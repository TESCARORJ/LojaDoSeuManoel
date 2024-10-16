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
    public class PedidoDomainService : IPedidoDomainService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IValidator<Pedido> _validator;

        public PedidoDomainService(IPedidoRepository pedidoRepository, IValidator<Pedido> validator)
        {
            _pedidoRepository = pedidoRepository;
            _validator = validator;
        }

        public async Task<Pedido> AddAsync(Pedido pedido)
        {
            var validatorResult = await _validator.ValidateAsync(pedido);

            if (validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            await _pedidoRepository.AddAsync(pedido);
            return pedido;
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {

            if (pedido == null)
            {
                throw new Exception("Pedido inválido");
            }

            if (!await _pedidoRepository.VerifyExistsAsync(x => x.PedidoId == pedido.PedidoId))
            {
                throw new PedidoNotFoundException(pedido.PedidoId);
            }

            //if (_validator is PedidoValidator validator)
            //    validator.SetCurrentPedidoId(pedido.PedidoId);

            var validatorResult = await _validator.ValidateAsync(pedido);
            if (validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            await _pedidoRepository.UpdateAsync(pedido);
            return pedido;

        }

        public async Task<Pedido> DeleteAsync(long id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
            {
                throw new PedidoNotFoundException(id);
            }

            await _pedidoRepository.DeleteAsync(pedido);
            return pedido;
        }

        public Task<Pedido> GetByIdAsync(long id)
        {
            return _pedidoRepository.GetByIdAsync(id);
        }

      

        public void Dispose()
        {
            _pedidoRepository.Dispose();
        }

     
    }
}

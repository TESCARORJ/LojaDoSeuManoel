using FluentValidation;
using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Validations
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private long _currentPedidoId;

        public PedidoValidator(IPedidoRepository pedidoRepository, long currentPedidoId)
        {
            _pedidoRepository = pedidoRepository;
            _currentPedidoId = currentPedidoId;
        }

        //método para receber o ID da Pedido
        public void SetCurrentPedidoId(long currentPedidoId)
        {
            _currentPedidoId = currentPedidoId;
        }

        public void ConfigRules()
        {
            RuleFor(p => p.PedidoId)
                .NotEmpty()
                .WithMessage("O PedidoId não pode ser vazio");

            RuleFor(p => p.Produtos)
                .NotEmpty()
                .WithMessage("O Pedido deve ter pelo menos um produto");
        }
    }
}

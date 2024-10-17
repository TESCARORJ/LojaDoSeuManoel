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

        public PedidoValidator(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            ConfigRules();

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

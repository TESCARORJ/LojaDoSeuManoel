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
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoValidator(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
            ConfigRules();

        }

        public void ConfigRules() 
        {          

            RuleFor(p => p.ProdutoId)
                .NotEmpty().WithMessage("O campo ProdutoId é obrigatório")
                .MaximumLength(100).WithMessage("O campo ProdutoId deve ter no máximo 100 caracteres");

            RuleFor(x => x)
                .MustAsync(async (dimensao, cancellation) =>
                !await _produtoRepository.VerifyExistsAsync(
                    d => d.ProdutoId == dimensao.ProdutoId))
                .WithMessage("Produto já cadastrado");

        }
    }
}

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
        private string _currentProdutoId;

        public ProdutoValidator(IProdutoRepository produtoRepository, string currentProdutoId)
        {
            _produtoRepository = produtoRepository;
            _currentProdutoId = currentProdutoId;
        }

        //método para receber o ID da Produto
        public void SetCurrentProdutoId(string currentProdutoId)
        {
            _currentProdutoId = currentProdutoId;
        }

        public void ConfigRules() 
        {          

            RuleFor(p => p.ProdutoId)
                .NotEmpty().WithMessage("O campo ProdutoId é obrigatório")
                .MaximumLength(100).WithMessage("O campo ProdutoId deve ter no máximo 100 caracteres");

        }
    }
}

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
    public class CaixaValidator : AbstractValidator<Caixa>
    {
        private readonly ICaixaRepository _caixaRepository;
        //private string _currentCaixaId;

        public CaixaValidator(ICaixaRepository caixaRepository
            //, string currentCaixaId
            )
        {
            _caixaRepository = caixaRepository;
            //_currentCaixaId = currentCaixaId;
            ConfigRules();

        }

        //método para receber o ID da Caixa
        //public void SetCurrentCaixaId(string currentCaixaId)
        //{
        //    _currentCaixaId = currentCaixaId;
        //}

        public void ConfigRules() 
        {          

            RuleFor(p => p.CaixaId)
                .NotEmpty().WithMessage("O campo CaixaId é obrigatório")
                .MaximumLength(100).WithMessage("O campo CaixaId deve ter no máximo 100 caracteres");

            RuleFor(x => x)
                .MustAsync(async (dimensao, cancellation) =>
                !await _caixaRepository.VerifyExistsAsync(
                    d => d.CaixaId == dimensao.CaixaId))
                .WithMessage("Caixa já cadastrado");

        }
    }
}

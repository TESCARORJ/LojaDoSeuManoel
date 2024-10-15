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
    public class DimensaoValidator : AbstractValidator<Dimensao>
    {
        private readonly IDimensaoRepository _dimensaoRepository;
        private int _currentDimensaoId;
        private double _currentDimensaoAltura;
        private double _currentDimensaoLargura;
        private double _currentDimensaoComprimento;

        public DimensaoValidator(IDimensaoRepository dimensaoRepository, int currentDimensaoId, double currentDimensaoAltura, double currentDimensaoLargura, double currentDimensaoComprimento)
        {
            _dimensaoRepository = dimensaoRepository;
            _currentDimensaoId = currentDimensaoId;
            _currentDimensaoAltura = currentDimensaoAltura;
            _currentDimensaoLargura = currentDimensaoLargura;
            _currentDimensaoComprimento = currentDimensaoComprimento;
        }

        //método para receber o ID da Dimensão
        public void SetCurrentDimensaoId(int currentDimensaoId)
        {
            _currentDimensaoId = currentDimensaoId;
        }

        public void SetCurrentDimensaoValores(double altura, double largura, double comprimento)
        {
            _currentDimensaoAltura = altura;
            _currentDimensaoLargura = largura;
            _currentDimensaoComprimento = comprimento;
        }

        public void ConfigRules()
        {
            RuleFor(x => x.Altura)
                .GreaterThan(0)
                .WithMessage("A altura deve ser maior que 0");

            RuleFor(x => x.Largura)
                .GreaterThan(0)
                .WithMessage("A largura deve ser maior que 0");

            RuleFor(x => x.Comprimento)
                .GreaterThan(0)
                .WithMessage("O comprimento deve ser maior que 0");


            RuleFor(x => x)
                .MustAsync(async (dimensao, cancellation) =>
                !await _dimensaoRepository.VerifyExistsAsync(
                    d => d.Largura == dimensao.Largura &&
                    d.Comprimento == dimensao.Comprimento &&
                    d.Altura == dimensao.Altura))
                .WithMessage("Dimensão já registrada");

        }






    }
}

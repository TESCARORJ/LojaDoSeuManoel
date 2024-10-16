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
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IValidator<Produto> _validator;

        public ProdutoDomainService(IProdutoRepository produtoRepository, IValidator<Produto> validator)
        {
            _produtoRepository = produtoRepository;
            _validator = validator;
        }

        public async Task<Produto> AddAsync(Produto produto)
        {
            var validatorResult = await _validator.ValidateAsync(produto);

            if (validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }
            await _produtoRepository.AddAsync(produto);
            return produto;
        }

        public async Task<Produto> UpdateAsync(Produto produto)
        {

            if (produto == null)
            {
                throw new Exception("Produto inválido");
            }

            if (!await _produtoRepository.VerifyExistsAsync(x => x.Id == produto.Id))
            {
                throw new ProdutoNotFoundException(produto.Id);
            }

            //if (_validator is ProdutoValidator validator)
            //    validator.SetCurrentProdutoId(produto.ProdutoId);

            var validatorResult = await _validator.ValidateAsync(produto);
            if (validatorResult.IsValid)
            {
                throw new ValidationException(validatorResult.Errors);
            }

            await _produtoRepository.UpdateAsync(produto);
            return produto;

        }

        public async Task<Produto> DeleteAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            if (produto == null)
            {
                throw new ProdutoNotFoundException(id);
            }

            await _produtoRepository.DeleteAsync(produto);
            return produto;
        }

        public Task<Produto> GetByIdAsync(int id)
        {
            return _produtoRepository.GetByIdAsync(id);
        }

      

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }

     
    }
}

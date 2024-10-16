using LojaDoSeuManoel.Domain.Entites;
using LojaDoSeuManoel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDoSeuManoel.Domain.Interfaces.Services
{
    public class EmpacotamentoServico : IEmpacotamentoServico
    {
        private readonly ICaixaRepository _caixaRepository;

        public EmpacotamentoServico(ICaixaRepository caixaRepository)
        {
            _caixaRepository = caixaRepository;
        }

        public List<Caixa> Empacotar(List<Produto> produtos)
        {
            var caixasUsadas = new List<Caixa>();

            foreach (var produto in produtos)
            {
                bool alocado = false;

                foreach (var caixa in caixasUsadas)
                {
                    if (ProdutoCabeNaCaixa(produto, caixa))
                    {
                        caixa.Produtos.Add(produto);
                        alocado = true;
                        break;
                    }
                }

                if (!alocado)
                {
                    var caixaDisponivel = SelecionarCaixaDisponivel(produto);
                    if (caixaDisponivel != null)
                    {
                        caixaDisponivel.Produtos.Add(produto);
                        caixasUsadas.Add(caixaDisponivel);
                    }
                    else
                    {
                        throw new Exception($"Produto {produto.ProdutoId} não cabe em nenhuma caixa disponível.");
                    }
                }
            }

            return caixasUsadas;
        }

        private bool ProdutoCabeNaCaixa(Produto produto, Caixa caixa)
        {
            return produto.Dimensao?.Altura <= caixa.Dimensao?.Altura &&
                   produto.Dimensao.Largura <= caixa.Dimensao.Largura &&
                   produto.Dimensao.Comprimento <= caixa.Dimensao.Comprimento;
        }

        private Caixa SelecionarCaixaDisponivel(Produto produto)
        {
            List<Caixa> caixasDisponiveis = _caixaRepository.GetManyAsync(x => x.Id > 0).Result.ToList();
            
            foreach (var caixa in caixasDisponiveis)
            {
                if (ProdutoCabeNaCaixa(produto, caixa))
                {
                    return new Caixa
                    {
                        CaixaId = caixa.CaixaId,
                        Dimensao = caixa.Dimensao,
                        Produtos = new List<Produto>()
                    };
                }
            }
            return null;
        }
    }
}

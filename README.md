# Loja Do Seu Manoel

## Descrição do Projeto

Este projeto é uma API Web desenvolvida para processar pedidos de uma loja. 
A API recebe uma lista de pedidos em formato JSON, onde cada pedido contém produtos com suas dimensões.
O objetivo é determinar a melhor forma de embalar esses produtos utilizando caixas pré-fabricadas, otimizando o uso do espaço e minimizando o número de caixas necessárias.

## Descrição do Problema

A API deve receber pedidos no formato JSON, onde cada pedido contém produtos, cada um com as suas dimensões (altura, largura, comprimento). As caixas disponíveis para embalagem são:

- **Caixa 1**: 30 x 40 x 80 cm
- **Caixa 2**: 80 x 50 x 40 cm
- **Caixa 3**: 50 x 80 x 60 cm

### Entrada e Saída do Endpoint

- **Entrada**: A API aceita um JSON contendo N pedidos diferentes, cada um com entre N produtos. Cada produto inclui suas dimensões em centímetros (altura, largura, comprimento).

- **Processamento**: Para cada pedido, a API calcula a melhor forma de embalar os produtos, utilizando uma ou mais caixas disponíveis e otimizando o espaço.

- **Saída**: A API retorna um JSON que lista as caixas usadas e quais produtos foram colocados em cada caixa para cada pedido.

## Tecnologias e Conceitos Utilizados

- **ASP.NET CORE 8**
- **Domain-Driven Design (DDD)**
- **Entity Framework Core**
- **CORS**
- **AutoMapper**
- **CQRS**
- **MediatR**
- **JSON**
- **MongoDB** (para queries)
- **SQL Server** (para operações de DELETE, INSERT, UPDATE)

## Autenticação

Para se autenticar na API, utilize as seguintes credenciais:

- **Username**: `LDSM_Tescaro`
- **Password**: `thiagotescaro2024`

## Repositórios no Docker Hub

Os seguintes repositórios estão disponíveis no Docker Hub:

- **API**: [thiagotescarorj/lojadoseumanoel](https://hub.docker.com/r/thiagotescarorj/lojadoseumanoel)
- **SQL Server**: [thiagotescarorj/sqlserver_ldsm](https://hub.docker.com/r/thiagotescarorj/sqlserver_ldsm)
- **MongoDB**: [thiagotescarorj/mongodb_ldsm](https://hub.docker.com/r/thiagotescarorj/mongodb_ldsm)

## Adição de registros (opcional)

INSERT INTO TB_Dimensao 
VALUES 
(30,40,80),
(80,50,40),
(50,80,60)


INSERT INTO TB_CAIXA (CaixaId, DimensaoId, Observacao, PedidoId)
VALUES 
('Caixa 1',1, NULL, NULL),
('Caixa 2',2, NULL, NULL),
('Caixa 3',3, NULL, NULL)

## Como Usar

1. Clone este repositório.
2. Configure o ambiente de desenvolvimento ou utilize os contêineres do Docker.
3. Execute a aplicação e faça requisições à API utilizando as credenciais mencionadas.
4. Envie um JSON com os pedidos e receba a resposta com as caixas e produtos.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou pull requests.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

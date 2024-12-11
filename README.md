# Aplicação de Teste Taking

Esta é uma aplicação de teste simples chamada "Taking" que implementa uma API para gerenciar vendas.

## Estrutura da Aplicação

A aplicação é construída usando .NET 8, utilizando Minimal APIs. A arquitetura permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) relacionadas a vendas.

## Operações da API

- **GET /api/sales**: Para obter todas as vendas.
- **GET /api/sales/{id}**: Para obter uma venda específica pelo ID.
- **POST /api/sales**: Para criar uma nova venda.
- **PUT /api/sales/{id}**: Para atualizar uma venda existente.
- **DELETE /api/sales/{id}**: Para deletar uma venda.

  ![image](https://github.com/user-attachments/assets/713783a9-fbde-473f-b32b-8d2910d744c9)


### Implementação do Banco de Dados em Memória
- **Singleton**: Como não foi solicitado utilizar banco de dados e nem ORM, optei para utilizar uma espécie de banco em memória para demostração utilizando o singleton para manter.
#### InMemorySaleRepository

A classe `InMemorySaleRepository` é responsável por armazenar e gerenciar as vendas em um banco de dados em memória, seguindo a interface `ISaleRepository`. Essa abordagem é útil para testes e desenvolvimento, uma vez que não requer configuração de um banco de dados real.

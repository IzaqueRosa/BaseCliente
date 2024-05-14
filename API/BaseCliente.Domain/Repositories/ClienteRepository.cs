using BaseCliente.Data.DataBase;
using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseCliente.Domain.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly BaseClienteContext _dbContext;

        public ClienteRepository(BaseClienteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _dbContext.Cliente.Attach(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> BuscarPorId(string idCliente)
        {
            int _idCliente = int.Parse(idCliente);
            return await _dbContext.Cliente.FirstOrDefaultAsync(f => f.Id == _idCliente);
        }

        public List<ClienteResponseDto> BuscarTodos(string nome, string idBanco)
        {
            var dados = (from cliente in _dbContext.Cliente
                         join banco in _dbContext.Banco on cliente.IdBanco equals banco.Id
                         select new ClienteResponseDto
                         {
                             IdCliente = cliente.Id,
                             Nome = cliente.Nome,
                             CPF = cliente.CPF,
                             Banco = banco.Nome,
                             DataCriacao = banco.DataCriacao,
                             IdBanco = cliente.IdBanco.ToString()
                         }
                         ).ToList();

            if (!string.IsNullOrWhiteSpace(nome))
                dados = dados.Where(w => w.Nome.ToLower().Contains(nome.ToLower())).ToList();

            if (!string.IsNullOrWhiteSpace(idBanco))
                dados = dados.Where(w => w.IdBanco == idBanco).ToList();

            return dados;
        }

        public async Task Excluir(Cliente cliente)
        {
            _dbContext.Cliente.Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cliente> Inserir(Cliente cliente)
        {
            await _dbContext.Cliente.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> ValidarVinculoBancoCliente(string idBanco)
        {
            int _idBanco = int.Parse(idBanco);
            return await _dbContext.Cliente.FirstOrDefaultAsync(f => f.IdBanco == _idBanco);
        }
    }
}

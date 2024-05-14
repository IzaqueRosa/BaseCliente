using BaseCliente.Data.DataBase;
using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BaseCliente.Domain.Repositories
{
    public class BancoRepository : IBancoRepository
    {
        private readonly BaseClienteContext _dbContext;

        public BancoRepository(BaseClienteContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Banco> Alterar(Banco banco)
        {
            _dbContext.Banco.Attach(banco);
            await _dbContext.SaveChangesAsync();
            return banco;
        }

        public async Task<Banco> BuscarPorId(string idBanco)
        {
            int _idBanco = int.Parse(idBanco);
            return await _dbContext.Banco.FirstOrDefaultAsync(f => f.Id == _idBanco); ;
        }

        public async Task<List<Banco>> BuscarTodos()
        {
            return await _dbContext.Banco.ToListAsync();
        }

        public List<BancoResponseDto> BuscarTodosComFiltro(string nome)
        {
            var dados = (from banco in _dbContext.Banco
                         select new BancoResponseDto
                         {
                             IdBanco = banco.Id.ToString(),
                             Nome = banco.Nome,
                             DataCriacao = banco.DataCriacao
                         }).ToList();
                
            if (!string.IsNullOrWhiteSpace(nome))
                dados = dados.Where(w => w.Nome.ToLower().Contains(nome.ToLower())).ToList();

            return dados;
        }

        public async Task Excluir(Banco banco)
        {
            _dbContext.Banco.Remove(banco);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Banco> Inserir(Banco banco)
        {
            await _dbContext.Banco.AddAsync(banco);
            await _dbContext.SaveChangesAsync();
            return banco;
        }
    }
}

using BaseCliente.Data.DataBase;
using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Repositories;
using BaseCliente.Domain.Interfaces.Services;

namespace BaseCliente.Domain.Services
{

    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;
        

        public BancoService(IBancoRepository bancoRepository, BaseClienteContext dbContext)
        {
            _bancoRepository = bancoRepository;
        }

        public async Task<Banco> Alterar(string idBanco, string nome)
        {
            Banco banco = await _bancoRepository.BuscarPorId(idBanco);
            if (banco != null)
            {
                banco.Nome = nome;
            }

            return await _bancoRepository.Alterar(banco);
        }

        public async Task<Banco> BuscarPorId(string idBanco)
        {
            return await _bancoRepository.BuscarPorId(idBanco);
        }

        public async Task<List<Banco>> BuscarTodos()
        {
            return await _bancoRepository.BuscarTodos();
        }

        public List<BancoResponseDto> BuscarTodosComFiltro(string nome)
        {
            return _bancoRepository.BuscarTodosComFiltro(nome);
        }

        public async Task Excluir(string idBanco)
        {
            Banco banco = await _bancoRepository.BuscarPorId(idBanco);
            if (banco != null)
            {
                await _bancoRepository.Excluir(banco);
            }
        }

        public async Task<Banco> Inserir(string nome)
        {
            Banco banco = new Banco()
            {
                Nome = nome,
                DataCriacao = DateTime.Now
            };

            return await _bancoRepository.Inserir(banco);
        }
    }
}

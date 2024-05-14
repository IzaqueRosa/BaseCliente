using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;

namespace BaseCliente.Domain.Interfaces.Services
{
    public interface IBancoService
    {
        Task<Banco> Alterar(string idBanco, string nome);
        Task<Banco> BuscarPorId(string idBanco);
        Task<List<Banco>> BuscarTodos();
        List<BancoResponseDto> BuscarTodosComFiltro(string nome);
        Task Excluir(string idBanco);
        Task<Banco> Inserir(string nome);
    }
}

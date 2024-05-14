using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;

namespace BaseCliente.Domain.Interfaces.Repositories
{
    public interface IBancoRepository
    {
        Task<Banco> Alterar(Banco banco);
        Task<Banco> BuscarPorId(string idBanco);
        Task<List<Banco>> BuscarTodos();
        List<BancoResponseDto> BuscarTodosComFiltro(string nome);
        Task Excluir(Banco banco);
        Task<Banco> Inserir(Banco banco);
    }
}

using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;

namespace BaseCliente.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> Alterar(Cliente cliente);
        Task<Cliente> BuscarPorId(string idCliente);
        List<ClienteResponseDto> BuscarTodos(string nome, string idBanco);
        Task Excluir(Cliente cliente);
        Task<Cliente> Inserir(Cliente cliente);
        Task<Cliente> ValidarVinculoBancoCliente(string idBanco);
    }
}

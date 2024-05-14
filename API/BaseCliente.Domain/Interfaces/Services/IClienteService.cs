using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;

namespace BaseCliente.Domain.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> Alterar(string idCliente, string nome, string idBanco, string cpf);
        Task<Cliente> BuscarPorId(string idCliente);
        List<ClienteResponseDto> BuscarTodos(string nome, string idBanco);
        Task Excluir(string idCliente);
        Task<Cliente> Inserir(string nome, string idBanco, string cpf);
    }
}

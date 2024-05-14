using BaseCliente.Data.Models;
using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Repositories;
using BaseCliente.Domain.Interfaces.Services;

namespace BaseCliente.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> Alterar(string idCliente, string nome, string idBanco, string cpf)
        {
            Cliente cliente = await _clienteRepository.BuscarPorId(idCliente);
            if (cliente != null)
            {
                cliente.Nome = nome;
                cliente.CPF = cpf;
                cliente.IdBanco = int.Parse(idBanco);
            }

            return await _clienteRepository.Alterar(cliente);
        }

        public async Task<Cliente> BuscarPorId(string idCliente)
        {
            return await _clienteRepository.BuscarPorId(idCliente);
        }

        public List<ClienteResponseDto> BuscarTodos(string nome, string idBanco)
        {
            return _clienteRepository.BuscarTodos(nome, idBanco);
        }

        public async Task Excluir(string idCliente)
        {
            Cliente cliente = await _clienteRepository.BuscarPorId(idCliente);
            if(cliente != null)
            {
                await _clienteRepository.Excluir(cliente);
            }
        }

        public async Task<Cliente> Inserir(string nome, string idBanco, string cpf)
        {
            Cliente cliente = new Cliente() {
                Nome = nome,
                IdBanco = int.Parse(idBanco),
                CPF = cpf,
                DataCriacao = DateTime.Now
            };

            return await _clienteRepository.Inserir(cliente);
        }
    }
}

using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseClienteAPI.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas aos clientes.
    /// </summary>
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        /// <summary>
        /// Construtor da classe ClienteController.
        /// </summary>
        /// <param name="clienteService">Serviço de cliente injetado.</param>
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Busca todos os clientes com base em um filtro.
        /// </summary>
        /// <param name="clienteRequestDto">DTO contendo o filtro de busca.</param>
        [HttpPost]
        [Route("buscarTodos")]
        public IActionResult BuscarTodos([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(_clienteService.BuscarTodos(clienteRequestDto.Nome, clienteRequestDto.IdBanco));
        }

        /// <summary>
        /// Busca um cliente pelo seu ID.
        /// </summary>
        /// <param name="IdCliente">ID do cliente.</param>
        [HttpGet]
        [Route("buscarPorId/{IdCliente}")]
        public async Task<IActionResult> BuscarPorId(string IdCliente)
        {
            return Ok(await _clienteService.BuscarPorId(IdCliente));
        }

        /// <summary>
        /// Insere um novo cliente.
        /// </summary>
        /// <param name="clienteRequestDto">DTO contendo os dados do cliente a ser inserido.</param>
        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(await _clienteService.Inserir(clienteRequestDto.Nome, clienteRequestDto.IdBanco, clienteRequestDto.Cpf));
        }

        /// <summary>
        /// Altera um cliente existente.
        /// </summary>
        /// <param name="clienteRequestDto">DTO contendo os dados do cliente a ser alterado.</param>
        [HttpPost]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(await _clienteService.Alterar(clienteRequestDto.IdCliente, clienteRequestDto.Nome, clienteRequestDto.IdBanco, clienteRequestDto.Cpf));
        }

        /// <summary>
        /// Exclui um cliente pelo seu ID.
        /// </summary>
        /// <param name="IdCliente">ID do cliente a ser excluído.</param>
        [HttpGet]
        [Route("excluir/{IdCliente}")]
        public async Task<IActionResult> Excluir(string IdCliente)
        {
            await _clienteService.Excluir(IdCliente);
            return Ok();
        }
    }
}

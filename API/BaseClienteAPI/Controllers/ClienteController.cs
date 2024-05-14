using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseClienteAPI.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        [Route("buscarTodos")]
        public IActionResult BuscarTodos([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(_clienteService.BuscarTodos(clienteRequestDto.Nome, clienteRequestDto.IdBanco));
        }

        [HttpGet]
        [Route("buscarPorId/{IdCliente}")]
        public async Task<IActionResult> BuscarPorId(string IdCliente)
        {
            return Ok(await _clienteService.BuscarPorId(IdCliente));
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(await _clienteService.Inserir(clienteRequestDto.Nome, clienteRequestDto.IdBanco, clienteRequestDto.Cpf));
        }

        [HttpPost]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] ClienteRequestDto clienteRequestDto)
        {
            return Ok(await _clienteService.Alterar(clienteRequestDto.IdCliente, clienteRequestDto.Nome, clienteRequestDto.IdBanco, clienteRequestDto.Cpf));
        }

        [HttpGet]
        [Route("excluir/{IdCliente}")]
        public async Task<IActionResult> Excluir(string IdCliente)
        {
            await _clienteService.Excluir(IdCliente);
            return Ok();
        }
    }
}

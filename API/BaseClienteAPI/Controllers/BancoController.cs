using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseClienteAPI.Controllers
{
    [ApiController]
    [Route("api/banco")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        [HttpPost]
        [Route("buscarTodosComFiltro")]
        public IActionResult BuscarTodosComFiltro([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(_bancoService.BuscarTodosComFiltro(bancoRequestDto.Nome));
        }

        [HttpGet]
        [Route("buscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            return Ok(await _bancoService.BuscarTodos());
        }

        [HttpGet]
        [Route("buscarPorId/{idBanco}")]
        public async Task<IActionResult> BuscarPorId(string idBanco)
        {
            return Ok(await _bancoService.BuscarPorId(idBanco));
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(await _bancoService.Inserir(bancoRequestDto.Nome));
        }

        [HttpPost]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(await _bancoService.Alterar(bancoRequestDto.IdBanco, bancoRequestDto.Nome));
        }

        [HttpGet]
        [Route("excluir/{idBanco}")]
        public async Task<IActionResult> Excluir(string idBanco)
        {
            await _bancoService.Excluir(idBanco);
            return Ok();
        }
    }
}

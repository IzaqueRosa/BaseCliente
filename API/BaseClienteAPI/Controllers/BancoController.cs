using BaseCliente.Data.Models.Dtos;
using BaseCliente.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BaseClienteAPI.Controllers
{
    /// <summary>
    /// Controller responsável pelas operações relacionadas aos bancos.
    /// </summary>
    [ApiController]
    [Route("api/banco")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoService _bancoService;

        /// <summary>
        /// Construtor da classe BancoController.
        /// </summary>
        /// <param name="bancoService">Serviço de banco injetado.</param>
        public BancoController(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        /// <summary>
        /// Busca todos os bancos com base em um filtro.
        /// </summary>
        /// <param name="bancoRequestDto">DTO contendo o filtro de busca.</param>
        [HttpPost]
        [Route("buscarTodosComFiltro")]
        public IActionResult BuscarTodosComFiltro([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(_bancoService.BuscarTodosComFiltro(bancoRequestDto.Nome));
        }

        /// <summary>
        /// Busca todos os bancos.
        /// </summary>
        [HttpGet]
        [Route("buscarTodos")]
        public async Task<IActionResult> BuscarTodos()
        {
            return Ok(await _bancoService.BuscarTodos());
        }

        /// <summary>
        /// Busca um banco pelo seu ID.
        /// </summary>
        /// <param name="idBanco">ID do banco.</param>
        [HttpGet]
        [Route("buscarPorId/{idBanco}")]
        public async Task<IActionResult> BuscarPorId(string idBanco)
        {
            return Ok(await _bancoService.BuscarPorId(idBanco));
        }

        /// <summary>
        /// Insere um novo banco.
        /// </summary>
        /// <param name="bancoRequestDto">DTO contendo os dados do banco a ser inserido.</param>
        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(await _bancoService.Inserir(bancoRequestDto.Nome));
        }

        /// <summary>
        /// Altera um banco existente.
        /// </summary>
        /// <param name="bancoRequestDto">DTO contendo os dados do banco a ser alterado.</param>
        [HttpPost]
        [Route("alterar")]
        public async Task<IActionResult> Alterar([FromBody] BancoRequestDto bancoRequestDto)
        {
            return Ok(await _bancoService.Alterar(bancoRequestDto.IdBanco, bancoRequestDto.Nome));
        }

        /// <summary>
        /// Exclui um banco pelo seu ID.
        /// </summary>
        /// <param name="idBanco">ID do banco a ser excluído.</param>
        [HttpGet]
        [Route("excluir/{idBanco}")]
        public async Task<IActionResult> Excluir(string idBanco)
        {
            await _bancoService.Excluir(idBanco);
            return Ok();
        }

        /// <summary>
        /// Validar se banco está vinculado a cliente.
        /// </summary>
        /// <param name="idBanco">ID do banco a ser excluído.</param>
        [HttpGet]
        [Route("validarVinculoCliente/{idBanco}")]
        public async Task<IActionResult> ValidarVinculoCliente(string idBanco)
        {
            return Ok(await _bancoService.ValidarVinculoCliente(idBanco));
        }
    }
}

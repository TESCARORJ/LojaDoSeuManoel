using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(ProdutoResponseDTO), 201)]
        public async Task<IActionResult> Post([FromBody] ProdutoRequestDTO request)
        {
            return StatusCode(201, await _produtoService.AddAsync(request));
        }

        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(ProdutoResponseDTO), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody] ProdutoRequestDTO request)
        {
            return StatusCode(200, await _produtoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(ProdutoResponseDTO), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(200, await _produtoService.DeleteAsync(id));
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(ProdutoResponseDTO), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return StatusCode(200, await _produtoService.GetByIdAsync(id));
        }

    }
}

using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PedidoResponseDTO), 201)]
        public async Task<IActionResult> Post([FromBody] PedidoRequestDTO request)
        {
            return StatusCode(201,await _pedidoService.AddAsync(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> Put(Guid id,[FromBody] PedidoRequestDTO request)
        {
            return StatusCode(200, await _pedidoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(200,await _pedidoService.DeleteAsync(id));
        }       

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return StatusCode(200,await _pedidoService.GetByIdAsync(id));
        }

    }
}

using LojaDoSeuManoel.API.Security;
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
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            return StatusCode(201,await _pedidoService.AddAsync(request));
        }

        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> Put(Guid id,[FromBody] PedidoRequestDTO request)
        {
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            return StatusCode(200, await _pedidoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            return StatusCode(200,await _pedidoService.DeleteAsync(id));
        }       

        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(PedidoResponseDTO), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            return StatusCode(200,await _pedidoService.GetByIdAsync(id));
        }

    }
}

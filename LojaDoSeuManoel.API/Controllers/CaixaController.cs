using LojaDoSeuManoel.API.Security;
using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixaController : ControllerBase
    {
        private readonly ICaixaService _caixaService;

        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(CaixaResponseDTO), 201)]
        public async Task<IActionResult> Post([FromBody] CaixaRequestDTO request)
        {
            return StatusCode(201, await _caixaService.AddAsync(request));
        }

        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(CaixaResponseDTO), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody] CaixaRequestDTO request)
        {
            return StatusCode(200, await _caixaService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(CaixaResponseDTO), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(200, await _caixaService.DeleteAsync(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CaixaResponseDTO>), 200)]
        public async Task<IActionResult> GetAll()
        {
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            var result = await _caixaService.GetAllAsync();
            return StatusCode(200, result);
        }

    }
}

﻿using LojaDoSeuManoel.API.Security;
using LojaDoSeuManoel.Application.DTOs;
using LojaDoSeuManoel.Application.Interfaces;
using LojaDoSeuManoel.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaDoSeuManoel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensaoController : ControllerBase
    {
        private readonly IDimensaoService _dimensaoService;

        public DimensaoController(IDimensaoService dimensaoService)
        {
            _dimensaoService = dimensaoService;
        }

        [HttpPost]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(DimensaoResponseDTO), 201)]
        public async Task<IActionResult> Post([FromBody] DimensaoRequestDTO request)
        {
            return StatusCode(201, await _dimensaoService.AddAsync(request));
        }

        [HttpPut("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(DimensaoResponseDTO), 200)]
        public async Task<IActionResult> Put(Guid id, [FromBody] DimensaoRequestDTO request)
        {
            return StatusCode(200, await _dimensaoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(DimensaoResponseDTO), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return StatusCode(200, await _dimensaoService.DeleteAsync(id));
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(typeof(DimensaoResponseDTO), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return StatusCode(200, await _dimensaoService.GetByIdAsync(id));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CaixaResponseDTO>), 200)]
        public async Task<IActionResult> GetAll()
        {
            if (!BasicAuthenticationSecurity.AuthenticateRequest(Request))
            {
                return Unauthorized(new { Message = "Autenticação falhou. Credenciais inválidas." });
            }

            return StatusCode(200, await _dimensaoService.GetAllAsync());
        }

    }
}

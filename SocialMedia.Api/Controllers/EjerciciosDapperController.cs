using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.Services;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjerciciosDapperController : ControllerBase
    {
        private readonly IEjerciciosDapperService _ejerciciosDapperService;
        public EjerciciosDapperController(IEjerciciosDapperService ejerciciosDapperService)
        {
            _ejerciciosDapperService = ejerciciosDapperService;
            
        }
        [HttpGet("primero")]
        public async Task<IActionResult> PrimerEjercicio()
        {

            var result = await _ejerciciosDapperService.PrimerEjerciciosDapperAsync();
            
            return Ok(result);
        }
        [HttpGet("tercero")]
        public async Task<IActionResult> TercerEjercicio()
        {

            var result = await _ejerciciosDapperService.TercerEjerciciosDapperAsync();

            return Ok(result);
        }
        [HttpGet("cuarto")]
        public async Task<IActionResult> CuartoEjercicio()
        {

            var result = await _ejerciciosDapperService.CuartoEjerciciosDapperAsync();

            return Ok(result);
        }
        [HttpGet("quinto")]
        public async Task<IActionResult> QuintoEjercicio()
        {

            var result = await _ejerciciosDapperService.QuintoEjerciciosDapperAsync();

            return Ok(result);
        }
        [HttpGet("sexto")]
        public async Task<IActionResult> SextoEjercicio()
        {

            var result = await _ejerciciosDapperService.SextoEjerciciosDapperAsync();

            return Ok(result);
        }
    }
}

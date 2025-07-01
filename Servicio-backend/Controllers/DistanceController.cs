using BusinessLayer.Interfaces;
using DomainModel.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Servicio_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcularDistanciaController : ControllerBase
    {
        private readonly IDistanceService _distanceService;

        public CalcularDistanciaController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] DistanceRequest request)
        {
            if (request.Latitude < -90 || request.Latitude > 90 ||
                request.Longitude < -180 || request.Longitude > 180)
            {
                return BadRequest("Coordenadas fuera de rango.");
            }

            var result = _distanceService.CalculateDistance(request);
            return Ok(result);
        }
    }
}

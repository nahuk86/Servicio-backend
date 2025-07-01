using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Servicio_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly IClientService _clientService;

        public CitiesController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_clientService.GetAllCities());
    }
}

using BancoOccidente.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BancoOccidente.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet("GetByDocument")]
        public async Task<IActionResult> GetCustomerByDocument([FromQuery] string documentId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(documentId))
                {
                    return BadRequest("Documento es requerido");
                }
                var result = await _customerService.GetCustomerByDocument(documentId);

                if (result == null)
                {
                    return NotFound("No se ha encontrado el usuario");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}

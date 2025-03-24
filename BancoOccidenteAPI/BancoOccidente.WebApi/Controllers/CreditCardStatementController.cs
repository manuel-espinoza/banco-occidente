using BancoOccidente.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BancoOccidente.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardStatementController : ControllerBase
    {
        private readonly ICreditCardStatementService _creditCardStatementService;

        public CreditCardStatementController(ICreditCardStatementService creditCardStatementService)
        {
            _creditCardStatementService = creditCardStatementService;
        }

        [HttpGet("GetHeaderInformation/{customerId}")]
        public async Task<IActionResult> GetHeaderInformation(int customerId)
        {
            try
            {
                var result = await _creditCardStatementService.GetHeaderByCustomer(customerId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving header information: {ex.Message}");
            }
        }

        // TODO: Se podria crear una paginacion si las cantidad de compras es muy grande. Tambien el filtro cambiaria a query params para usar size y page
        [HttpGet("GetPurchasesInformation/{customerId}/{month}")]
        public async Task<IActionResult> GetPurchasesInformation(int customerId, int month)
        {
            try
            {
                var result = await _creditCardStatementService.GetPurchasesByCustomerAndMonth(month, customerId);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrievieng pruchases: {ex.Message}");
            }
        }
    }
}

using BancoOccidente.Service.DTOs;
using BancoOccidente.Service.IServices;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BancoOccidente.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsReadService _transactionsReadService;
        private readonly ICreditCardService _creditCardService;
        private readonly ITransactionsWriteService _transactionsWriteService;
        private readonly IValidator<TransactionDTO> _transactionValidator;

        public TransactionsController(ITransactionsReadService transactionsReadService, ICreditCardService creditCardService, IValidator<TransactionDTO> validator, ITransactionsWriteService transactionsWriteService)
        {
            _transactionsReadService = transactionsReadService;
            _creditCardService = creditCardService;
            _transactionValidator = validator;
            _transactionsWriteService = transactionsWriteService;
        }

        [HttpGet("GetTransactionsByCreditCard")]
        public async Task<IActionResult> GetTransactionsByCreditCard(string creditCardNumber, int month)
        {
            try
            {
                if (string.IsNullOrEmpty(creditCardNumber))
                {
                    return BadRequest("Credit card number is required");
                }
                if (month < 1 || month > 12)
                {
                    return BadRequest("Month must be between 1 and 12");
                }

                var creditCard = await _creditCardService.GetCreditCardByNumber(creditCardNumber);
                if (creditCard == null)
                {
                    return NotFound("Credit card not found");
                }

                var result = await _transactionsReadService.GetTransactionsByCreditCardAndMonth(creditCard.CreditCardId, month);
                if (result != null)
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error on get transactions list:  {ex.Message}");
            }
        }

        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDTO transaction)
        {
            try
            {
                if (transaction == null)
                {
                    return BadRequest("Transaction data is required");
                }
                var validationResult = _transactionValidator.Validate(transaction);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var creditCard = await _creditCardService.GetCreditCardByNumber(transaction.CreditCardNumber!);

                transaction.CreditCardId = creditCard!.CreditCardId;

                var result = await _transactionsWriteService.AddTransaction(transaction);

                if (result)
                {
                    return CreatedAtAction(nameof(GetTransactionsByCreditCard), "Creado exitosamente");
                }
                else
                {
                    return BadRequest("No se pudo crear la transaccion");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating transaction {ex.Message}");
            }
        }
    }
}

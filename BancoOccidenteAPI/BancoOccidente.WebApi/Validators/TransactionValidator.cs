using BancoOccidente.Service.DTOs;
using FluentValidation;

namespace BancoOccidente.WebApi.Validators
{
    public class TransactionValidator : AbstractValidator<TransactionDTO>
    {
        public TransactionValidator()
        {
            RuleFor(x => x.TransactionDate).NotEmpty().WithMessage("La fecha de la transaccion es obligatoria");
            RuleFor(x => x.CreditCardNumber).NotEmpty().WithMessage("El numero de la tarjeta de credito es obligatorio");
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Ingrese un monto valido");
            RuleFor(x => x.Description).NotEmpty().WithMessage("La descripcion es obligatoria");
            RuleFor(x => x.TransactionType).NotEmpty().WithMessage("El tipo de transaccion es obligatorio")
                                           .Must(ValidateTransactionType).WithMessage("El tipo de transaccion es invalido");
        }

        private bool ValidateTransactionType(string type)
        {
            return type == "cargo" || type == "abono";
        }
    }
}

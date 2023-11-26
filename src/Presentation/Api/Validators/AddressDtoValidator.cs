using Cinema.Theater.Application.Dtos.Address;
using FluentValidation;

namespace Api.Validators
{
	public class AddressDtoValidator : AbstractValidator<AddressDto?>
	{
        public AddressDtoValidator()
        {
            RuleFor(_ => _.Street1).NotEmpty().WithMessage("Street 1 must not be null, empty or whitespace.");
            RuleFor(_ => _.City).NotEmpty().WithMessage("The city is required");
            RuleFor(_ => _.Country).NotEmpty().WithMessage("The country is required");
            RuleFor(_ => _.PostalCode).NotEmpty().WithMessage("The postal code is required");
        }
    }
}

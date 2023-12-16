using Cinema.Application.Dtos.Theater;
using FluentValidation;

namespace Api.Validators
{
	public class TheaterForCreationDtoValidator : AbstractValidator<TheaterForCreationDto>
	{
        public TheaterForCreationDtoValidator()
        {
            RuleFor(mt => mt.Name).NotEmpty().MinimumLength(5).MaximumLength(100).WithMessage("The name must have length caracters between 5 and 100");
        }
    }
}

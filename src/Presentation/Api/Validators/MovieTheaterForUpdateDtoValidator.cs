using Cinema.Theater.Application.Dtos.MovieTheater;
using FluentValidation;

namespace Api.Validators
{
	public class MovieTheaterForUpdateDtoValidator : AbstractValidator<MovieTheaterForUpdateDto>
	{
        public MovieTheaterForUpdateDtoValidator()
        {
            RuleFor(_ => _.Name).NotEmpty().WithMessage("The name must not be null, empty or whitespace");
            RuleFor(_ => _.Name).MinimumLength(5).WithMessage("The length of the name must be minimum 5 characters");

            RuleFor(_ => _.NumberOfPlaces).GreaterThan(0).WithMessage("The length must not be less then 1");

            RuleFor(_ => _.Address).NotNull().WithMessage("The address can't be null");
            RuleFor(_ => _.Address).SetValidator(new AddressDtoValidator());
		}
    }
}

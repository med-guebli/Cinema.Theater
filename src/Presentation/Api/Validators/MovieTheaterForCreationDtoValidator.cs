using Cinema.Theater.Application.Dtos.MovieTheater;
using FluentValidation;

namespace Api.Validators
{
	public class MovieTheaterForCreationDtoValidator : AbstractValidator<MovieTheaterForCreationDto>
	{
        public MovieTheaterForCreationDtoValidator()
        {
            RuleFor(mt => mt.Name).NotEmpty().MinimumLength(5).MaximumLength(100).WithMessage("The name must have length caracters between 5 and 100");
        }
    }
}

using Cinema.Theater.Application.Dtos.SearchFilters;
using FluentValidation;

namespace Api.Validators
{
	public class TextSearchFilterDtoValidator : AbstractValidator<TextSearchFilterDto>
	{
        public TextSearchFilterDtoValidator()
        {
            RuleFor(_ => _.Search).NotNull().WithMessage("The search field must not be null");
		}
    }
}

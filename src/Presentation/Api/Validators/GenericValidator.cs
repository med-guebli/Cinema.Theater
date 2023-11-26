using FluentValidation;
using FluentValidation.Results;

namespace Api.Validators
{
	public class GenericValidator : IGenericValidator
	{
		private readonly IServiceProvider _provider;

		public GenericValidator(IServiceProvider provider)
        {
			_provider = provider;
		}


		public async Task<ValidationResult> ValidateAsync<TInstance>(TInstance instance)
			where TInstance : class
		{
			var validator = _provider.GetRequiredService<IValidator<TInstance>>();
			return await validator.ValidateAsync(instance);
		}
	}

	public interface IGenericValidator
	{
		Task<ValidationResult> ValidateAsync<TInstance>(TInstance instance)
			where TInstance : class;
	}
}

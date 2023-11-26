
using FluentValidation;
using FluentValidation.Results;
using Serilog;
using Serilog.Events;

namespace Api.Middlewares
{
	public class ErrorLoggerMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorLoggerMiddleware(RequestDelegate next)
        {
			_next = next;
		}

        public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var validationFailures = Enumerable.Empty<ValidationFailure>();

				if (ex is ValidationException validationException)
				{
					validationFailures = validationException.Errors;
				}


				var error = new
				{
					Id = Guid.NewGuid(),
					Message = ex.Message,
					DateTime = DateTime.UtcNow,
					Level = Enum.GetName(typeof(LogLevel), LogLevel.Error),
					ValidationFailures = validationFailures
				};

				Log
					.ForContext("id", error.Id)
					.ForContext("message", ex.Message)
					.ForContext("datetime", error.DateTime)
					.ForContext("level", LogEventLevel.Error)
					.ForContext("@validation_failures", validationFailures)
					.Error("An error occured : {id}", error.Id);

				context.Response.StatusCode = 500;
				await context.Response.WriteAsJsonAsync(error);
			}
		}
	}
}

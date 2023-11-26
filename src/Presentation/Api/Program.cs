
using Api.Middlewares;
using Api.Validators;
using Cinema.Theater.Application.Interfaces.Repositories;
using Cinema.Theater.Application.Interfaces.Services;
using Cinema.Theater.Application.Services;
using Data;
using Data.Configurations;
using DnsClient;
using FluentValidation;
using Mapster;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;

namespace Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				var builder = WebApplication.CreateBuilder(args);
				
				builder.Host.UseSerilog((ctx, config) => config.ReadFrom.Configuration(ctx.Configuration));

				var logger = new LoggerConfiguration()
							.ReadFrom
							.Configuration(builder.Configuration)
							.CreateBootstrapLogger();

				// Add services to the container.

				builder.Services.AddControllers();
				builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

				// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
				builder.Services.AddEndpointsApiExplorer();
				builder.Services.AddSwaggerGen();

				builder.Services.AddTransient<IMovieTheaterService, MovieTheaterService>();
				builder.Services.RegisterDataServices(builder.Configuration);

				var app = builder.Build();

				// Configure the HTTP request pipeline.
				if (app.Environment.IsDevelopment())
				{
					app.UseSwagger();
					app.UseSwaggerUI(options =>
					{
						options.DocumentTitle = "Cinema Theater API";
					});
				}

				app.UseMiddleware<ErrorLoggerMiddleware>();
				
				app.UseRouting();
				app.UseHttpsRedirection();
				app.UseAuthorization();

				app.UseEndpoints((config) =>
				{
					config.MapControllers();
				});

				app.Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Application terminated unexpectedly");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}
	}
}
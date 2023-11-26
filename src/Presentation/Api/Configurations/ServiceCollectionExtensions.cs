using Api.Validators;
using Cinema.Theater.Application.Dtos.MovieTheater;
using Cinema.Theater.Application.Dtos.SearchFilters;
using Cinema.Theater.Application.Interfaces.Repositories;
using Data.Configuration;
using Data.Repositories.MovieTheaterRepository;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterDataServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IMongoClient, MongoClient>((provider) =>
			{
				var options = configuration.GetRequiredSection(ConnectionStringsConfiguration.ConnectionStrings).Get<ConnectionStringsConfiguration>();
				return new MongoClient(options!.MongoDbConnection);
			});
			services.AddScoped<IMovieTheaterRepository, MovieTheaterRepository>();

			return services;
		}
	}
}

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Domain.Entities
{
    public record Theater : SearchableEntity
    {
        public required string Name { get; init; }

        public required uint NumberOfPlaces { get; init; }

		public required Address Address { get; init; }
	}
}
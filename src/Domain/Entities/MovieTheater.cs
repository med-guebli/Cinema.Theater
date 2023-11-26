using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinema.Theater.Domain.Entities
{
    public record MovieTheater : IAuditableEntity, ISearchScore
    {
        [BsonRepresentation(BsonType.String)]
        public required Guid Id { get; init; }

        public required string Name { get; init; }

        public required uint NumberOfPlaces { get; init; }

        [BsonRepresentation(BsonType.String)]
        public DateTime CreatedOn { get; init; }

		[BsonRepresentation(BsonType.String)]
		public DateTime? UpdatedOn { get; init; }

        public string? ChangedBy { get; init; }

		public required Address Address { get; init; }

        [BsonIgnoreIfNull]
		public double? SearchScore { get; init; }
	}
}
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
	public abstract record SearchableEntity : IAuditableEntity, ISearchScore
	{
		[BsonRepresentation(BsonType.String)]
		public required Guid Id { get; init; }

		[BsonRepresentation(BsonType.String)]
		public DateTime CreatedOn { get; init; }

		[BsonRepresentation(BsonType.String)]
		public DateTime? UpdatedOn { get; init; }

		public string? ChangedBy { get; init; }

		[BsonIgnoreIfNull]
		public double? SearchScore { get; init; }
	}
}

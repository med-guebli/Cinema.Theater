namespace Cinema.Theater.Domain.Entities
{
    public record Address
    {
		public required string Street1 { get; init; }

        public string? Street2 { get; init; }

        public string? Street3 { get; init; }

        public required string City { get; init; }

        public required string PostalCode { get; init; }

        public required string Country { get; init; }
	}
}
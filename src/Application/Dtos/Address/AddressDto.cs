namespace Cinema.Application.Dtos.Address
{
    public record AddressDto
	{
        public required string Street1 { get; init; }

        public string? Street2 { get; init; }

        public string? Street3 { get; init; }

        public required string City { get; init; }

        public required string PostalCode { get; init; }

        public required string Country { get; init; }
    }
}

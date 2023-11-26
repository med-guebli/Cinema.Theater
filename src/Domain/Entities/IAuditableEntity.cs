namespace Cinema.Theater.Domain.Entities
{
    public interface IAuditableEntity
    {
		Guid Id { get; init; }

		DateTime CreatedOn { get; init; }

        DateTime? UpdatedOn { get; init; }

        string? ChangedBy { get; init; }
    }
}
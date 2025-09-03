namespace RealState.Contracts.Request.Owners.GetAll;

public sealed class GetAllOwnersRequest
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateOnly? BirthdayMin { get; set; }
    public DateOnly? BirthdayMax { get; set; }
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public string? SortDir { get; set; }
}

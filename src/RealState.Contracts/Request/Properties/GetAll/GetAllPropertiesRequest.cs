namespace RealState.Contracts.Request.Properties.GetAll;

public sealed class GetAllPropertiesRequest
{
    public Guid? IdOwner { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? CodeInternal { get; set; }
    public decimal? PriceMin { get; set; }
    public decimal? PriceMax { get; set; }
    public int? YearMin { get; set; }
    public int? YearMax { get; set; }
    public DateTime? CreatedFrom { get; set; }
    public DateTime? CreatedTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SortBy { get; set; }
    public string? SortDir { get; set; }
}
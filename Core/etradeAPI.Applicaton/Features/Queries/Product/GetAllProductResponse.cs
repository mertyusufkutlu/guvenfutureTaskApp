using etradeAPI.Domain.Entites;

namespace etradeAPI.Applicaton.Features.Queries.GetAllProduct;

public class GetAllProductResponse
{
    public int TotalCount { get; set; }
    public Product Products { get; set; }
}
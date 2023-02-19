using etradeAPI.Domain.Entites;
using MediatR;

namespace etradeAPI.Applicaton.Features.Queries.GetAllProduct;

public class GetAllProductQueryRequest : IRequest<List<Product>>
{
    public Guid Id { get; set; }
}
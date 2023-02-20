using MediatR;

namespace etradeAPI.Applicaton.Features.Queries.CustomerBasket;

public class GetCustomerBasketByIdQueryRequest : IRequest<List<Domain.Entites.CustomerBasket>>
{
    public Guid UserId { get; set; }
}
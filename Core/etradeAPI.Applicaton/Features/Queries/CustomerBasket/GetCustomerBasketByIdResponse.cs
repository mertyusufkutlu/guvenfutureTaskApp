using etradeAPI.Domain.Entites;

namespace etradeAPI.Applicaton.Features.Queries.CustomerBasket;

public class GetCustomerBasketByIdResponse
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}
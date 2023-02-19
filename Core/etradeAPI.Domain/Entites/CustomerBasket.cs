using etradeAPI.Domain.Entites.Common;

namespace etradeAPI.Domain.Entites;

public class CustomerBasket : BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }

    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}
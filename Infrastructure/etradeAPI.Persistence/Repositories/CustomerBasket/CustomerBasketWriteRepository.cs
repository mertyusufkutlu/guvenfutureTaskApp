using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using etradeAPI.Persistence.Contexts;

namespace etradeAPI.Persistence.Repositories
{
public class CustomerBasketWriteRepository : WriteRepository<CustomerBasket>, ICustomerBasketWriteRepository
{
    public CustomerBasketWriteRepository(etradeAPIDbContext context) : base(context)
    {
    }
}
}
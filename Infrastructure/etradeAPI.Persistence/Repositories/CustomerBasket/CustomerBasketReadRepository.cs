using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using etradeAPI.Persistence.Contexts;

namespace etradeAPI.Persistence.Repositories
{
    public class CustomerBasketReadRepository : ReadRepository<CustomerBasket>, ICustomerBasketReadRepository
    {
        public CustomerBasketReadRepository(etradeAPIDbContext context) : base(context)
        {
        }
    }
}
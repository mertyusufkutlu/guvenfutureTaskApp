using etradeAPI.Applicaton.Repositories;
using etradeAPI.Domain.Entites;
using etradeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etradeAPI.Persistence.Repositories
{
    public class ProductGroupReadRepository : ReadRepository<Domain.Entites.ProductGroup>,  IProductGroupReadRepository
    {
        public ProductGroupReadRepository(etradeAPIDbContext context) : base(context)
        {
        }
    }
}
using etradeAPI.Domain.Entites;
using etradeAPI.Domain.Entites.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etradeAPI.Persistence.Contexts
{
    public class etradeAPIDbContext : DbContext
    {
        public etradeAPIDbContext(DbContextOptions options) : base(options)
        {
            //IoC Conteiner'da dolduralacak
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserDto> Users { get; set; }
        public DbSet<CustomerBasket> CustomerBaskets { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker : Entityler uzerinden yapilan degisiklik veya yeni eklenen verinin yakalanmasini saglayan propertiydir. Upgrade operasyonlarin da Track edilen verileri yakaylayip elde etmemizi saglar.

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                    _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,

                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

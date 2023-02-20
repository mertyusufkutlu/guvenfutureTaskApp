using etradeAPI.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace etradeAPI.Domain.Entites
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        public Guid ProductGroupId { get; set; }
        
        [JsonIgnore]
        public ProductGroup ProductGroup { get; set; }
        
        public ICollection<Order>? Orders { get; set; }
    }
}
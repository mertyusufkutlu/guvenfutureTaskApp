using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using etradeAPI.Domain.Entites;

namespace etradeAPI.Applicaton.ViewModels.CustomerBasket;

public class VM_CustomerBasket
{
    public Guid UserId { get; set; }

    public Guid ProductId { get; set; }
}
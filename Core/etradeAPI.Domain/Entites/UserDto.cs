using etradeAPI.Domain.Entites.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etradeAPI.Domain.Entites
{
    public class UserDto : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Passowrd { get; set; } = string.Empty;
    }
}

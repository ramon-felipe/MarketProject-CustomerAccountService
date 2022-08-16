using MarketProject.CustomerAccountService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.DTOs
{
    public record CustomerAccountDTO(Address Address, Email Email);
}

using MarketProject.CustomerAccountService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Queries.Interfaces
{
    public interface IGetCustomerAccountQuery
    {
        CustomerAccount Execute(int customerAccountId);
    }
}

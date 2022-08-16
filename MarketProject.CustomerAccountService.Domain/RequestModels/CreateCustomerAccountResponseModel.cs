using MarketProject.CustomerAccountService.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.RequestModels
{
    public class CustomerAccountResponseModel
    {
        public Address Address { get; set; }
        public Email Email { get; set; }

        public CustomerAccountResponseModel(Address address, Email email)
        {
            this.Address = address;
            this.Email = email;
        }
    }
}

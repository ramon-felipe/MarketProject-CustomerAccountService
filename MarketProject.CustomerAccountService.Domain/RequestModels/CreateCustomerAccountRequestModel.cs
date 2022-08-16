using Ardalis.GuardClauses;
using MarketProject.CustomerAccountService.Domain.DTOs;
using MarketProject.CustomerAccountService.Domain.Entities;
using MarketProject.CustomerAccountService.Domain.ValueObjects;
using NullGuard;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Domain.RequestModels
{
    public class CreateCustomerAccountRequestModel
    {
        public int CustomerId { get; set; }
        public AddressDTO Address { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public CreateCustomerAccountRequestModel(int customerId, AddressDTO address, string email)
        {
            this.CustomerId = customerId;
            this.Address = address;
            this.Email = email;
        }   
    }
}

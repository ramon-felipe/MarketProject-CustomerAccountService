using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Persistence.Models
{
    public class CustomerAccount : PersistentObject
    {
        public int CustomerId { get; set; }
        public string StreetName { get; set; } = string.Empty;
        
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;
    }
}

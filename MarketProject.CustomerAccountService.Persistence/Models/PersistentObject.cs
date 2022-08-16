using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Persistence.Models
{
    public abstract class PersistentObject
    {
        [Key]
        public int Id { get; set; }

    }
}

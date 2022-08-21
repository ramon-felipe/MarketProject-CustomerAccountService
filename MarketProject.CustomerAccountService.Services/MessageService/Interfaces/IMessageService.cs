using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Services.MessageService.Interfaces
{
    public interface IMessageService
    {
        void Consume(string queueName);
    }
}

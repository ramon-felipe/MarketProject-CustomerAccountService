using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Persistence.CQRS.Commands.Interfaces
{
    public interface IBaseCommand
    {
        void Execute();
    }
}

using LinkOracle.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Hubs.Clients
{
    public interface IGuiaClient
    {
        Task ReceiveMessage(Guia guia);
    }
}

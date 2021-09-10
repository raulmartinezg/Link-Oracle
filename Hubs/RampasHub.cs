using LinkOracle.Entities;
using LinkOracle.Hubs.Clients;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Hubs
{
    public class RampasHub : Hub<IGuiaClient>
    {
        public async Task Send(Guia guia)
        {
            await Clients.All.ReceiveMessage(guia);
        }
    }
}

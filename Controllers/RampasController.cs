using LinkOracle.Entities;
using LinkOracle.Hubs;
using LinkOracle.Hubs.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RampasController : ControllerBase
    {
        private IHubContext<RampasHub,IGuiaClient> _hubcontext;

        public RampasController(IHubContext<RampasHub,IGuiaClient> hubcontext)
        {
            _hubcontext = hubcontext;
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(Guia guia)
        {
            await _hubcontext.Clients.All.ReceiveMessage(guia);
            return Ok("Item enviado");
        }
    }
}

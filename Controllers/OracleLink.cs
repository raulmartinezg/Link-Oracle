using LinkOracle.Entities;
using LinkOracle.Interfaz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkOracle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OracleLink : ControllerBase
    {
        private readonly IRepository _repository;

        public OracleLink(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Endpoint dedicado al sincronizado de datos OTM GetShipments
        /// </summary>
        /// <returns></returns>

        [HttpGet("GetShipment")]
        public async Task<IActionResult> LinkOracle()
        {
            var data = await Service.Oracle.GetShipments(); 
            var response = await _repository.UpdateShip(data.Viaje);
            var response2 = await _repository.UpdateStop(data.Stop);
            await _repository.Delete();
            var response3 = await _repository.Insert(data.Folios);
            return Ok(response&&response2&&response3);
        }

        /// <summary>
        /// Endpoint dedicado al sincronizado de datos OTM GetShipments
        /// </summary>
        /// <returns></returns>

        [HttpGet("LinkShipment")]
        public async Task<IActionResult> LinkShipment([FromQuery]LinkShip link)
        {
            var data = await Service.Link.GetLinkShipment(link);
            var response = await _repository.UpdateLink(data);
            return Ok(response);
        }


    }
}

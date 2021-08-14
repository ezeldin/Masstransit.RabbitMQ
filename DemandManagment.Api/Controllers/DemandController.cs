using DemandManagment.Api.Model;
using DemandManagment.MessagesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemandManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemandController : ControllerBase
    {
        // POST: api/Demand
        public async Task<ActionResult> Post([FromBody] RegisterDemandModel demand)
        {
            var bus = BusConfigurator.ConfigureBus();

            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.RegisterDemandServiceQueue}");
            var endPoint = await bus.GetSendEndpoint(sendToUri);

            await endPoint.Send<IRegisterDemandCommand>(new
            {
                Subject = demand.Subject,
                Description = demand.Description
            });

            return Ok("Thanks");
        }
    }

}

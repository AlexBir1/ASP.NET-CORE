using CommonWork;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace SenderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RMQController : ControllerBase
    {
        private readonly IBus _bus;

        public RMQController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("Test1")]
        public async Task<ActionResult> Test1()
        {
            var product = new Product
            {
                Name = "Item_1",
                Price = 500
            };

            Uri uri = new("rabbitmq://localhost/send-tutorial");

            var endpoint = await _bus.GetSendEndpoint(uri);
            await endpoint.Send(product);

            return Ok("Hello CST!");
        }

        [HttpPost("Test2")]
        public async Task<ActionResult> TestPublish([FromBody] Person person)
        {
            if (person is null) 
                return BadRequest("There was no info about a person");

            await _bus.Publish(person);

            return Ok("Hello CST!");
        }
    }
}

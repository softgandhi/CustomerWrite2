using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Events;
using CustomerWrite.Models;
using Microsoft.AspNetCore.Mvc;
using CustomerWrite.Events;
using CustomerWrite.Commands;

namespace CustomerWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICommandHandler _commandHandler;

        public CustomersController(ICommandHandler myevents)
        {
            _commandHandler = myevents;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Customers value)
        {
            CreateCustomerCommand customerCreated = new CreateCustomerCommand();

            // var customerCreated = new CustomerCreatedEvent();
            customerCreated.CustomerId = value.CustomerId;
            customerCreated.FirstName = value.FirstName;
            customerCreated.LastName = value.LastName;

            _commandHandler.ListenForCustomerCreatedCommand(customerCreated);
            // return cust;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customers value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

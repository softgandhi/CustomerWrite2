using CustomerWrite.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerCreatedEvent ToCustomerCreatedEvent()
        {
            return new CustomerCreatedEvent()
            {
                CustomerId = CustomerId,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}

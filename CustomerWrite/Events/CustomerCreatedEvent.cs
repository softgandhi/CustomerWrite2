using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public class CustomerCreatedEvent : IEvents
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Customers ToCustomerModel()
        {
            return new Customers()
            {
                CustomerId = CustomerId,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}

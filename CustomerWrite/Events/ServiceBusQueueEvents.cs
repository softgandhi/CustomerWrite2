using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace CustomerWrite.Events
{
    public class ServiceBusQueueEvents
    {
        public async Task SendEventsToQueue(IEvents events)
        {
            string connString = "Endpoint=sb://anuragsb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YGW0bjdKlAAkHBWjtNa6iD7l1gXPivlmv68lyDsIyio=";
            QueueClient client = new QueueClient(connString, "CustomerCreatedQueue");
            Message msg = new Message();

            Customer cust = new Customer
            {
                CustomerId = 100,
                FirstName = "Hello",
                LastName = "World"
            };
            var jsonData = JsonConvert.SerializeObject(cust);

            var byteData = Encoding.ASCII.GetBytes(jsonData);
            msg.Body = byteData;
            await client.SendAsync(msg);
        }

        public class Customer
        {
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}

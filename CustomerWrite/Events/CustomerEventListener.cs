using CustomerWrite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public class CustomerEventListener : IEventHandler
    {
        private ISQLRepository _repo;
        private ServiceBusQueueEvents _eventSender;

        public CustomerEventListener(ISQLRepository repo)
        {
            _repo = repo;
            _eventSender = new ServiceBusQueueEvents();
        }

        public async Task ListenForCustomerCreatedEvent(CustomerCreatedEvent createdEvent)
        {
            await _repo.AddCustomer(createdEvent.ToCustomerModel());
            await _eventSender.SendEventsToQueue(createdEvent);
        }
    }
}

using CustomerWrite.Events;
using CustomerWrite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Commands
{
    public class CustomerCommandHandler : ICommandHandler
    {
        private ISQLRepository _repo;
        private IEventHandler _eventHandler;

        public CustomerCommandHandler(ISQLRepository repo, IEventHandler eventHandler)
        {
            _repo = repo;
            _eventHandler = eventHandler;
        }

        public async Task ListenForCustomerCreatedCommand(CreateCustomerCommand cmd)
        {
            await _eventHandler.ListenForCustomerCreatedEvent(cmd.ToCustomerCreatedEvent());
        }
    }
}

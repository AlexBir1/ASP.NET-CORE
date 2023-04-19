using CommonWork;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiverApp
{
    public class ReceivingModule : IConsumer<Person>
    {
        public Task Consume(ConsumeContext<Person> context)
        {
            var info = context.Message;
            return Task.CompletedTask;
        }
    }
}

using CommonWork;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReceiverApp
{
    public class Receiving2Module : IConsumer<Product>
    {
        public Task Consume(ConsumeContext<Product> context)
        {
            var product = context.Message;
            return Task.CompletedTask;
        }
    }
}

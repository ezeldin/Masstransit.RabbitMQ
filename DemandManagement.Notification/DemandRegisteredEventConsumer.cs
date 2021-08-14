using DemandManagment.MessagesContract;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemandManagement.Notification
{
    public class DemandRegisteredEventConsumer : IConsumer<IDemandRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IDemandRegisteredEvent> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent demand id : {context.Message.DemandId} , {DateTime.Now}");
        }
    }
}

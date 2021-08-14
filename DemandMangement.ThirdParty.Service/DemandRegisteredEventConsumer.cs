using DemandManagment.MessagesContract;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DemandMangement.ThirdParty.Service
{
    public class DemandRegisteredEventConsumer : IConsumer<IDemandRegisteredEvent>
    {
        public async Task Consume(ConsumeContext<IDemandRegisteredEvent> context)
        {
            await Console.Out.WriteLineAsync($"Notification sent demand id : {context.Message.DemandId} , {DateTime.Now}");
        }
    }
}
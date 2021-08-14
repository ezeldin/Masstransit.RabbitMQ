using DemandManagment.MessagesContract;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace DemandManagment.Registration
{
    public class RegisterDemandCommandConsumer : IConsumer<IRegisterDemandCommand>
    {
        public Task Consume(ConsumeContext<IRegisterDemandCommand> context)
        {
            var message = context.Message;
            var guid = Guid.NewGuid();
            Console.WriteLine($"Demand successfully  registered. Subject:{message.Subject}, Description:{message.Description}, Id:{guid}, Time:{DateTime.Now}");
            //await Task.Delay(1000);
            context.Publish<IDemandRegisteredEvent>(new
            {
                DemandId = guid
            });

            return Task.CompletedTask;
        }
    }
}
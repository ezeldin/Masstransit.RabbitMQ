using DemandManagment.MessagesContract;
using MassTransit;
using System;

namespace DemandMangement.ThirdParty.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Third Party Service";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(
                    RabbitMqConsts.ThirdPartyServiceQueue, e =>
                    {
                        e.Consumer<DemandRegisteredEventConsumer>();
                    });

            });

            bus.StartAsync();

            Console.WriteLine("Listening for Demand Register Events .... " +
                              "Press enter to exit");
            Console.ReadLine();

            bus.StopAsync();
        }
    }
}

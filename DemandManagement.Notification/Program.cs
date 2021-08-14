using DemandManagment.MessagesContract;
using MassTransit;
using System;

namespace DemandManagement.Notification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Notification";

            var bus = BusConfigurator.ConfigureBus((cfg, host) =>
            {
                cfg.ReceiveEndpoint(
                    RabbitMqConsts.NotificationServiceQueue, e =>
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

using MassTransit;
using OrderProcessUsingMassTransitRabbitMq.Consumer;

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.Consumer<OrderCreatedConsumer>();
    });
});

busControl.StartAsync(new CancellationToken());

try
{
    Console.WriteLine("Press any key to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync(); 
}
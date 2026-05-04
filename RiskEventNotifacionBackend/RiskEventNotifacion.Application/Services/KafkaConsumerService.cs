using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace RiskEventNotifacion.Application.Services
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly IServiceScopeFactory scopeFactory;

        public KafkaConsumerService(IConfiguration configuration, IHubContext<NotificationHub> hubContext, IServiceScopeFactory scopeFactory)
        {
            this.configuration = configuration;
            this.hubContext = hubContext;
            this.scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var serverconfig = this.configuration["Kafka:BootstrapServers"];
                var groupId = this.configuration["Kafka:GroupId"];
                var topic = this.configuration["Kafka:Topic"];
                
                ConsumerConfig config = new ConsumerConfig
                {
                    BootstrapServers = serverconfig,
                    GroupId = groupId,
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

                consumer.Subscribe(topic);

                //String originConfig = JsonSerializer.Serialize(new { BootstrapServers = serverconfig, topic = topic, groupId = groupId });

                //using IServiceScope scope = this.scopeFactory.CreateScope();

                //IExternalNotificationLogsRepository repository = scope.ServiceProvider.GetRequiredService<IExternalNotificationLogsRepository>();

                //var resultLog = await repository.SaveLogsAsync(NotificationExternalLogType.KafkaConsumer, originConfig, "Mensaje de prueba");

                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("Esperando mensaje...");
                    var consumeResult = consumer.Consume(TimeSpan.FromSeconds(5));
                    //var consumeResult = consumer.Consume(stoppingToken);
                    Console.WriteLine("Mensaje recibido");
                    if (consumeResult != null)
                    {
                        Console.WriteLine(consumeResult.Message.Value);
                        //var notification = JsonSerializer.Deserialize<NotificationMessage>(
                        //    consumeResult.Message.Value);
                        var notification = consumeResult.Message.Value;

                        String originConfig = JsonSerializer.Serialize(new { BootstrapServers = serverconfig, topic = topic, groupId = groupId });
                        //String notificationText = JsonSerializer.Serialize<NotificationMessage>(notification);
                        using IServiceScope scope = this.scopeFactory.CreateScope();

                        IExternalNotificationLogsRepository repository = scope.ServiceProvider.GetRequiredService<IExternalNotificationLogsRepository>();

                        _ = await repository.SaveLogsAsync(NotificationExternalLogType.KafkaConsumer, originConfig, notification);

                        await this.hubContext.Clients.All.SendAsync(
                            "ReceiveNotification",
                            notification,
                            cancellationToken: stoppingToken);
                    }
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}

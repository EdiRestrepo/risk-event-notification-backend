using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RiskEventNotifacion.Application.Services
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly IConfiguration configuration;
        private readonly IHubContext<NotificationHub> hubContext;

        public KafkaConsumerService(IConfiguration configuration, IHubContext<NotificationHub> hubContext)
        {
            this.configuration = configuration;
            this.hubContext = hubContext;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                ConsumerConfig config = new ConsumerConfig
                {
                    BootstrapServers = this.configuration["Kafka:BootstrapServers"],
                    GroupId = this.configuration["Kafka:GroupId"],
                    AutoOffsetReset = AutoOffsetReset.Earliest
                };

                using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

                var topic = this.configuration["Kafka:Topic"];

                consumer.Subscribe(topic);

                while (!stoppingToken.IsCancellationRequested)
                {
                    Console.WriteLine("Esperando mensaje...");
                    //var consumeResult = consumer.Consume(TimeSpan.FromSeconds(2));
                    var consumeResult = consumer.Consume(stoppingToken);
                    Console.WriteLine("Mensaje recibido");
                    if (consumeResult != null)
                    {
                        Console.WriteLine(consumeResult.Message.Value);
                        //var notification = JsonSerializer.Deserialize<NotificationMessage>(
                        //    consumeResult.Message.Value);
                        var notification = consumeResult.Message.Value;

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

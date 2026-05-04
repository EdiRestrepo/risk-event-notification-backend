using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RiskEventNotifacion.Application.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IConfiguration configuration;
        private readonly IServiceScopeFactory scopeFactory;

        public KafkaProducerService(IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            this.configuration = configuration;
            this.scopeFactory = scopeFactory;
        }
        public async Task ProduceAsync(NotificationMessage message)
        {
            try
            {
                var serverconfig = this.configuration["Kafka:BootstrapServers"];
                ProducerConfig config = new ProducerConfig
                {
                    BootstrapServers = serverconfig,
                    MessageTimeoutMs = 5000
                };
                
                using var producer = new ProducerBuilder<Null, String>(config)
                    .SetErrorHandler((_, e) =>
                     {
                         Console.WriteLine($"Kafka Error: {e.Reason}");
                     })
                    .Build();
                try
                {
                    var topic = this.configuration["Kafka:Topic"];
                    var groupId = this.configuration["Kafka:GroupId"];

                    String messageJson = JsonSerializer.Serialize(message);
                    var result = await producer.ProduceAsync(topic, new Message<Null, String>
                    {
                        Value = messageJson
                    });

                    String originConfig = JsonSerializer.Serialize(new { BootstrapServers = serverconfig, topic = topic, groupId = groupId });

                    using IServiceScope scope = this.scopeFactory.CreateScope();

                    IExternalNotificationLogsRepository repository = scope.ServiceProvider.GetRequiredService<IExternalNotificationLogsRepository>();

                    var resultLog = await repository.SaveLogsAsync(NotificationExternalLogType.KafkaProducer, originConfig, messageJson);

                    //Console.WriteLine($"Mensaje enviado: {result.Offset}");
                }
                catch (ProduceException<Null, String> ex)
                {
                    Console.WriteLine($"ProduceException: {ex.Error.Reason}");
                    throw;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

        }
    }
}

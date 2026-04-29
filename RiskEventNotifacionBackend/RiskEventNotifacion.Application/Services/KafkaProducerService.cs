using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace RiskEventNotifacion.Application.Services
{
    public class KafkaProducerService : IKafkaProducerService
    {
        private readonly IConfiguration configuration;

        public KafkaProducerService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task ProduceAsync(NotificationMessage message)
        {
            try
            {
                ProducerConfig config = new ProducerConfig
                {
                    BootstrapServers = this.configuration["Kafka:BootstrapServers"],
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

                    var result = await producer.ProduceAsync(topic, new Message<Null, String>
                    {
                        Value = JsonSerializer.Serialize(message)
                    });
                    Console.WriteLine($"Mensaje enviado: {result.Offset}");
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

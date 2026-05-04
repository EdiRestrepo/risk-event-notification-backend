using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskEventNotifacion.Application.Entities;
using RiskEventNotifacion.Application.Interfaces;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Confluent.Kafka.ConfigPropertyNames;

namespace RiskEventNotifacion.Application.Services
{
    public class TraceProducerService : ITraceProducerService
    {
        private readonly IProducer<Null, String> producer;
        private readonly IConfiguration configuration;
        private readonly IServiceScopeFactory scopeFactory;

        public TraceProducerService(IProducer<Null, String> producer, IConfiguration configuration, IServiceScopeFactory scopeFactory)
        {
            this.producer = producer;
            this.configuration = configuration;
            this.scopeFactory = scopeFactory;
        }


        public async Task SendTraceAsync(ProcessTraceMessage trace)
        {
            var topic = this.configuration["Kafka:TraceTopic"];

            var payload = JsonSerializer.Serialize(trace);

            using IServiceScope scope = this.scopeFactory.CreateScope();

            IProcessTraceLogsRepository repository = scope.ServiceProvider.GetRequiredService<IProcessTraceLogsRepository>();
            ProcessTraceLog processTraceLog = new ProcessTraceLog 
            {
                CorrelationId = trace.CorrelationId,
                ProcessName = trace.ProcessName,
                StepName = trace.StepName,
                Status = trace.Status,
                Message = trace.Message
            };
            var resultLog = await repository.SaveTraceAsync(processTraceLog);

            await this.producer.ProduceAsync(
                topic,
                new Message<Null, string>
                {
                    Value = payload
                });
        }
    }
}

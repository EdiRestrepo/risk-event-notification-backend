using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RiskEventNotifacion.Application.Entities;
using RiskEventNotifacion.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Application.Services
{
    public class KafkaTraceLoggerProducer : ITraceLogger
    {
        private readonly ITraceProducerService producer;
        private readonly IServiceScopeFactory scopeFactory;

        public KafkaTraceLoggerProducer(ITraceProducerService producer, IServiceScopeFactory scopeFactory)
        {
            this.producer = producer;
        }
        public async Task LogAsync(TraceContext context, String layer, String step, String status, String message)
        {
            await this.producer.SendTraceAsync(
                new ProcessTraceMessage
                {
                    CorrelationId = context.CorrelationId,
                    ProcessName = context.ProcessName,
                    StepName = $"{layer}.{step}",
                    Status = status,
                    Message = message,
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}

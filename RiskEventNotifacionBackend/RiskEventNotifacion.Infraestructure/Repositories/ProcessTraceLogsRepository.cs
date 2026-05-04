using Dapper;
using Google.Protobuf;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Repositories
{
    public class ProcessTraceLogsRepository : IProcessTraceLogsRepository
    {
        private readonly MySqlConnectionFactory factory;

        public ProcessTraceLogsRepository(MySqlConnectionFactory factory)
        {
            this.factory = factory;
        }

        public async Task<Boolean> SaveTraceAsync(ProcessTraceLog trace)
        {
            Boolean isCorrect = false;
            using var connection = factory.CreateConnection();

            string sql = @"
            INSERT INTO process_trace_logs (correlation_id, process_name, step_name, STATUS, message, created_at)
            VALUES (@correlationid, @processname, @stepname, @status, @msg, @date)";

            Int16 result = (Int16)await connection.ExecuteAsync(sql,
                param: new
                {
                    correlationid = trace.CorrelationId,
                    processname = trace.ProcessName,
                    stepname = trace.StepName,
                    status = trace.Status,
                    msg = trace.Message,
                    date = DateTime.UtcNow,
                });

            if (result != 0)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}

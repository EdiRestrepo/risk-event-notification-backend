using Dapper;
using RiskEventNotifacion.Domain.Enum;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Repositories
{
    public class ExternalNotificationLogsRepository : IExternalNotificationLogsRepository
    {
        private readonly MySqlConnectionFactory factory;

        public ExternalNotificationLogsRepository(MySqlConnectionFactory factory)
        {
            this.factory = factory;
        }
        public async Task<Boolean> SaveLogsAsync(NotificationExternalLogType origin, String originConfiguration, String message)
        {
            Boolean isCorrect = false;
            using var connection = factory.CreateConnection();

            string sql = @"
            INSERT INTO externalnotificationlogs (origin, origin_configuration, message)
            VALUES (@origin, @originconfig, @msg)";

            Int16 result = (Int16)await connection.ExecuteAsync(sql,
                param: new
                {
                    origin = origin.ToString(),
                    originconfig = originConfiguration,
                    msg = message
                });

            if (result != 0) 
            {
                isCorrect = true;
            }
            return isCorrect;
        }
    }
}

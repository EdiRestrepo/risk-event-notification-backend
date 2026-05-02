using Dapper;
using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;

namespace RiskEventNotifacion.Infraestructure.Repositories
{
    public class UserChannelsRepository : IUserChannelsRepository
    {
        private readonly MySqlConnectionFactory _factory;

        public UserChannelsRepository(MySqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<Int16> CreateUserChannels(UserChannelsEntities userChannelsEntities)
        {
            using var connection = _factory.CreateConnection();

            string sql = @"
            INSERT INTO usuariochannels (IdUsuario, sms, email, push, whatsapp, username )
            VALUES (@idUsuario, @sms, @email, @push, @whatsapp, @idUsuario)";

            return (Int16)await connection.ExecuteAsync(sql, 
                param: new { idUsuario = userChannelsEntities.IdUsuario, sms = userChannelsEntities.Sms,
                    email = userChannelsEntities.Email, push = userChannelsEntities.Push, whatsapp= userChannelsEntities.WhatsApp});
        }

        public async Task<UserChannelsEntities> GetChannelsByUserId(String userId)
        {
            using var connection = _factory.CreateConnection();

            String sql = "SELECT IdUsuario, sms, email, push, whatsapp FROM usuariochannels WHERE username=@userName";

            return await connection.QueryFirstOrDefaultAsync<UserChannelsEntities>(sql, param: new { userName = userId });
        }

        public async Task<UserChannelsEntities> GetChannelsByUserName(String userName)
        {
            using var connection = _factory.CreateConnection();

            String sql = "SELECT IdUsuario, sms, email, push, whatsapp FROM usuariochannels WHERE IdUsuario=@idUsuario";

            return await connection.QueryFirstOrDefaultAsync<UserChannelsEntities>(sql, param: new { idUsuario = userName });
        }

        public async Task<Int16> UpdateUserChannels(UserChannelsEntities userChannelsEntities)
        {
            using var connection = _factory.CreateConnection();

            string sql = @"
            UPDATE usuariochannels SET sms=@sms, email=@email, push=@push, whatsapp=@whatsapp WHERE IdUsuario=@idUsuario";

            return (Int16)await connection.ExecuteAsync(sql,
                param: new
                {
                    idUsuario = userChannelsEntities.IdUsuario,
                    sms = userChannelsEntities.Sms,
                    email = userChannelsEntities.Email,
                    push = userChannelsEntities.Push,
                    whatsapp = userChannelsEntities.WhatsApp
                });
        }
    }
}

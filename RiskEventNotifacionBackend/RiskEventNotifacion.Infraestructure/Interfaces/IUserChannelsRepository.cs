using RiskEventNotifacion.Infraestructure.Entities;

namespace RiskEventNotifacion.Infraestructure.Interfaces
{
    public interface IUserChannelsRepository
    {
        Task<UserChannelsEntities> GetChannelsByUserId(String userId);
        Task<Int16> CreateUserChannels(UserChannelsEntities userChannelsEntities);
        Task<Int16> UpdateUserChannels(UserChannelsEntities userChannelsEntities);
        Task<UserChannelsEntities> GetChannelsByUserName(String userName);
    }
}

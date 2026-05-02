using RiskEventNotifacion.Infraestructure.Entities;

namespace RiskEventNotifacion.Infraestructure.Interfaces
{
    public interface IUsersApplicationRepository
    {
        Task<IEnumerable<UsersApplication>> GetListUsersAll();
        Task<UsersApplication> GetUserById(String userName);

        Task<UsersApplication> ValidateUserLogin(UsersApplication user);

        Task<Int16> CreateUser(UsersApplication usuario);
    }
}

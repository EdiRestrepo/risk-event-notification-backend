using RiskEventNotifacion.Domain.Entities;
using RiskEventNotifacion.Infraestructure.DataSimulation.DAO;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;

namespace RiskEventNotifacion.Infraestructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        public async Task<Boolean> ValidateUserAsync(User user)
        {
            UsersApplicationDAO usersApplicationDAO = UsersApplicationDAO.Instance;
            return usersApplicationDAO.UsersList.Any(u => u.User == user.UserName && u.Password == user.Password && u.IsActive == true);
        }
    }
}

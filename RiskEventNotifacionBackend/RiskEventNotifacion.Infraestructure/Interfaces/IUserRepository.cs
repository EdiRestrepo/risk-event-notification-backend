using RiskEventNotifacion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.Interfaces
{
    public interface IUserRepository
    {
        Task<Boolean> ValidateUserAsync(User user);
    }
}

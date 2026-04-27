using RiskEventNotifacion.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiskEventNotifacion.Infraestructure.DataSimulation.DAO
{
    public class UsersApplicationDAO
    {
        private static readonly Lazy<UsersApplicationDAO> _instance = new Lazy<UsersApplicationDAO>(() => new UsersApplicationDAO());
        public static UsersApplicationDAO Instance => _instance.Value;
        public List<UsersApplication> UsersList { get; private set; }

        private UsersApplicationDAO()
        {
            UsersList = new List<UsersApplication>();
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            UsersList.Add(new UsersApplication
            {
                User = "Juan",
                Password = "456",
                IsActive = false,
            });
            UsersList.Add(new UsersApplication
            {
                User = "Carlos",
                Password = "123",
                IsActive = true,
            });
            UsersList.Add(new UsersApplication
            {
                User = "Felipe",
                Password = "789",
                IsActive = true,
            });
            UsersList.Add(new UsersApplication
            {
                User = "Sara",
                Password = "423",
                IsActive = false,
            });
            UsersList.Add(new UsersApplication
            {
                User = "Melisa",
                Password = "753",
                IsActive = true,
            });
        }
    }
}

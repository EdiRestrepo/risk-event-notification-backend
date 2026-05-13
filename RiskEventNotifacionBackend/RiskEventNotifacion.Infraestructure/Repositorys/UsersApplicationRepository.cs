using Dapper;
using RiskEventNotifacion.Infraestructure.Entities;
using RiskEventNotifacion.Infraestructure.Interfaces;
using RiskEventNotifacion.Infraestructure.Persistence;

namespace RiskEventNotifacion.Infraestructure.Repositorys
{
    public class UsersApplicationRepository : IUsersApplicationRepository
    {
        private readonly MySqlConnectionFactory _factory;

        public UsersApplicationRepository(MySqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<UsersApplication>> GetListUsersAll()
        {
            using var connection = _factory.CreateConnection();

            string sql = "SELECT Id, Nombre, Email FROM usuarios";

            return await connection.QueryAsync<UsersApplication>(sql);
        }

        public async Task<UsersApplication> GetUserByUserName(String userName)
        {
            using var connection = _factory.CreateConnection();

            string sql = "SELECT * FROM usuarios WHERE username = @userName";

            return await connection.QueryFirstOrDefaultAsync<UsersApplication>(sql,param: new { userName = userName });
        }

        public async Task<Int16> CreateUser(UsersApplication usuario)
        {
            using var connection = _factory.CreateConnection();

            string sql = @"
            INSERT INTO usuarios (name, username, estado, password )
            VALUES (@name, @username, 1, @password)";

            return (Int16)await connection.ExecuteAsync(sql, param: new { name= usuario.Name, username=usuario.User, password=usuario.Password });
        }

        public Task<UsersApplication> GetUserById(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<UsersApplication> ValidateUserLogin(UsersApplication user)
        {
            using var connection = _factory.CreateConnection();

            string sql = "SELECT id,name FROM usuarios WHERE username = @userName and password = @password and estado=1";

            return await connection.QueryFirstOrDefaultAsync<UsersApplication>(sql, param: new { username = user.User, password = user.Password });
        }
    }
}

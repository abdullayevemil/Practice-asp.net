using System.Data.SqlClient;
using Dapper;
using Turbo.az.Models;
using Turbo.az.Repositories.Base;

namespace Turbo.az.Repositories;
public class UserSqlRepository : IUserRepository
{
    private readonly string connectionString;
    public UserSqlRepository(string connectionString) => this.connectionString = connectionString;
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        using var connection = new SqlConnection(connectionString);

        var vehicles = await connection.QueryAsync<User>("select * from Users");

        return vehicles;
    }
    public async Task InsertUserAsync(User user)
    {
        using var connection = new SqlConnection(connectionString);

        var vehicles = await connection.ExecuteAsync(
            sql: "insert into Users (Login, Password) values (@Login, @Password);",
            param: user);
    }
}
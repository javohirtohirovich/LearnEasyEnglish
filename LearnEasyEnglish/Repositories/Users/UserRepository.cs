using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Users;
using LearnEasyEnglish.Interfaces;
using LearnEasyEnglish.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.Users;

public class UserRepositor : IUsersRepository
{
    private readonly NpgsqlConnection _connection;
    public UserRepositor()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }
    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(User obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.users(id, first_name, last_name, email, phone_number, username, password_hash, salt, created_at, updated_at)" +
                "VALUES (@first_name, @last_name, @email, @phone_number, @username, @password_hash, @salt, @created_at, @updated_at)\r\n;";
            await using(var command=new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("first_name", obj.First_Name);
                command.Parameters.AddWithValue("last_name", obj.Last_Name);
                command.Parameters.AddWithValue("email", obj.Email);
                command.Parameters.AddWithValue("phone_number", obj.Phone_Number);
                command.Parameters.AddWithValue("username", obj.Username);
                command.Parameters.AddWithValue("password_hash", obj.Password_hash);
                command.Parameters.AddWithValue("salt", obj.Salt);
                command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);

                var dbResult = await command.ExecuteNonQueryAsync();
                return dbResult;

            }
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<User>> GetAllAsync(PagenationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, User editedObj)
    {
        throw new NotImplementedException();
    }
}

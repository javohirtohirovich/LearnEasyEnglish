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
            string query = "INSERT INTO public.users(id, first_name, last_name, email,password_hash, salt, created_at, updated_at)" +
                "VALUES (@first_name, @last_name, @email, @phone_number, @username, @password_hash, @salt, @created_at, @updated_at)\r\n;";
            await using(var command=new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("first_name", obj.First_Name);
                command.Parameters.AddWithValue("last_name", obj.Last_Name);
                command.Parameters.AddWithValue("email", obj.Email);
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

    public  async  Task<IList<User>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<User>();
            string query = $"select * from Users order by id ";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new User();
                        user.id = reader.GetInt64(0);
                        user.First_Name = reader.GetString(1);
                        user.Last_Name = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.Salt = reader.GetString(4);
                        user.Password_hash = reader.GetString(5);
                        user.CreatedAt = reader.GetDateTime(6);
                        user.UpdatedAt = reader.GetDateTime(7);
                        list.Add(user);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
    public async Task<IList<User>> GetAlluserPasswordHashSaltAsync(string name)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<User>();
            string query = $"SELECT * FROM public.users where first_name={name.ToLower()} order by id;";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new User();
                        user.id = reader.GetInt64(0);
                        user.First_Name = reader.GetString(1);
                        user.Last_Name = reader.GetString(2);
                        user.Email = reader.GetString(3);
                        user.Salt = reader.GetString(4);
                        user.Password_hash = reader.GetString(5);
                        user.CreatedAt = reader.GetDateTime(6);
                        user.UpdatedAt = reader.GetDateTime(7);
                        list.Add(user);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
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

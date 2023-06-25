using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Users;
using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Interfaces;
using LearnEasyEnglish.Interfaces.WordsGroup;
using LearnEasyEnglish.Utils;
using Microsoft.VisualBasic;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.WordsGroup;

public class WordsGroupRepository : IWordsGroupRepository
{
    private readonly NpgsqlConnection _connection;
    public WordsGroupRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }
    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Word_Group obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.words_groups(group_name, description, created_at, updated_at,user_id,image_path) " +
                "VALUES (@group_name, @description, @created_at, @updated_at,@user_id,@image_path);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("group_name", obj.Group_Name);
                command.Parameters.AddWithValue("description",obj.Description);
                command.Parameters.AddWithValue("created_at", obj.CreatedAt);
                command.Parameters.AddWithValue("updated_at", obj.UpdatedAt);
                command.Parameters.AddWithValue("user_id", obj.User_id);
                command.Parameters.AddWithValue("image_path", obj.ImagePath);
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

    public async Task<IList<Word_Group>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Word_Group>();
            string query = $"select * from words_groups order by id " +
                $"offset {(@params.PageNumber - 1) * @params.PageSize} " +
                $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var word_Group = new Word_Group();
                        word_Group.id = reader.GetInt64(0);
                        word_Group.Group_Name = reader.GetString(1);
                        word_Group.Description = reader.GetString(2);
                        word_Group.CreatedAt = reader.GetDateTime(3);
                        word_Group.UpdatedAt = reader.GetDateTime(4);
                        word_Group.User_id = reader.GetInt64(5);
                        word_Group.ImagePath= reader.GetString(6);
                        list.Add(word_Group);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Word_Group>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<Word_Group>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IList<Word_Group>> GetAlluserPasswordHashSaltAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Word_Group> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Word_Group editedObj)
    {
        throw new NotImplementedException();
    }
}
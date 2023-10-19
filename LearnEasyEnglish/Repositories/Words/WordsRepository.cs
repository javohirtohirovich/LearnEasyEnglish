using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Words;
using LearnEasyEnglish.Entities_Models.Words_Groups;
using LearnEasyEnglish.Interfaces.Words;
using LearnEasyEnglish.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.Words;

public class WordsRepository : IWordRepositorie
{
    private readonly NpgsqlConnection _connection;
    public WordsRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }
    public Task<int> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Word obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.words(word, sound_path, difination,groups_name,translated, created_at, updated_at)" +
                "VALUES (@word, @sound_path, @difination,@groups_name,@translated, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("word", obj.Word_text);
                command.Parameters.AddWithValue("sound_path", obj.Sound_path);
                command.Parameters.AddWithValue("difination", obj.DifinationText);
                command.Parameters.AddWithValue("groups_name", obj.GroupName);
                command.Parameters.AddWithValue("translated", obj.TranslatedText);
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"delete from words WHERE id = {id};";
            var command = new NpgsqlCommand(query, _connection);
            var result = await command.ExecuteNonQueryAsync();
            if (result != 0) { return 1; }
            else { return 0; }
        }
        catch
        {

            return 0;
        }
        finally { _connection.Close(); }
    }

    public async Task<IList<Word>> GetAllAsync(PagenationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Word>();
            string query = $"select * from words order by id"+
                $"offset {(@params.PageNumber - 1) * @params.PageSize} " +
                $"limit {@params.PageSize}";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var word = new Word();
                        word.id = reader.GetInt64(0);
                        word.Word_text = reader.GetString(1);
                        word.Sound_path = reader.GetString(2);
                        word.CreatedAt = reader.GetDateTime(3);
                        word.UpdatedAt = reader.GetDateTime(4);
                        word.DifinationText = reader.GetString(5);
                        word.GroupName = reader.GetString(6);
                        word.TranslatedText = reader.GetString(7);
                        list.Add(word);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Word>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<Word>> GetAllAsync()
    {
        try
        {
            await _connection.OpenAsync();
            var list = new List<Word>();
            string query = $"select * from Words order by id";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                await using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var word = new Word();
                        word.id = reader.GetInt64(0);
                        word.Word_text = reader.GetString(1);
                        word.Sound_path = reader.GetString(2);
                        word.CreatedAt = reader.GetDateTime(3);
                        word.UpdatedAt = reader.GetDateTime(4);
                        word.DifinationText = reader.GetString(5);
                        word.GroupName = reader.GetString(6);
                        word.TranslatedText = reader.GetString(7);
                        list.Add(word);
                    }
                }
            }
            return list;
        }
        catch
        {
            return new List<Word>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public Task<IList<Word>> GetAlluserPasswordHashSaltAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Word> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Word editedObj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE words set word = @word,translated = @translated,difination=@difination where id = '{id}';";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@word", editedObj.Word_text);
                command.Parameters.AddWithValue("@translated", editedObj.TranslatedText);
                command.Parameters.AddWithValue("@difination", editedObj.DifinationText);
                var dbresult = command.ExecuteNonQueryAsync();
                return dbresult.Result;
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
}

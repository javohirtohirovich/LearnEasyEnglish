using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Words;
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

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Word>> GetAllAsync(PagenationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Word>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IList<Word>> GetAlluserPasswordHashSaltAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Word> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Word editedObj)
    {
        throw new NotImplementedException();
    }
}

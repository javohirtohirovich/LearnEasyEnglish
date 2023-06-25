using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Result_Words;
using LearnEasyEnglish.Interfaces.Result_word;
using LearnEasyEnglish.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.Result_words;

public class ResultWordRepository : IResultWordRepository
{
    private readonly NpgsqlConnection _connection;
    public ResultWordRepository()
    {
        _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
    }
    public Task<int> Count()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(Result_Word obj)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.results_word(id, result_id, word, true_percentage, created_at, updated_at)" +
                "VALUES (@result_id, @word, @true_percentage, @created_at, @updated_at);";
            await using (var command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("result_id", obj.result_id);
                command.Parameters.AddWithValue("word", obj.word);
                command.Parameters.AddWithValue("true_percentage", obj.true_percentage);
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

    public Task<IList<Result_Word>> GetAllAsync(PagenationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Result_Word>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IList<Result_Word>> GetAlluserPasswordHashSaltAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<Result_Word> GetAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Result_Word editedObj)
    {
        throw new NotImplementedException();
    }
}

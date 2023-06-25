using LearnEasyEnglish.Constants;
using LearnEasyEnglish.Entities_Models.Results;
using LearnEasyEnglish.Interfaces.Results;
using LearnEasyEnglish.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasyEnglish.Repositories.Results
{
    public class ResultRepository : IResultRepository
    {
        private readonly NpgsqlConnection _connection;
        public ResultRepository()
        {
            _connection = new NpgsqlConnection(DbConstants.DB_CONNECTIONSTRING);
        }
        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Result obj)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.results(id, user_id, group_id, description, created_at, updated_at)" +
                    "VALUES (@user_id, @group_id, @description, @created_at, @updated_at);";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("user_id", obj.user_id);
                    command.Parameters.AddWithValue("group_id", obj.group_id);
                    command.Parameters.AddWithValue("description", obj.description);
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

        public Task<IList<Result>> GetAllAsync(PagenationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Result>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Result>> GetAlluserPasswordHashSaltAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Result> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, Result editedObj)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Data.SqlClient;
using System.Data;
using StoredProcedure.Configuration;
using Dapper;

namespace StoredProcedure.Repositories
{
    public interface ISqlDapperHelper
    {
        Task ExecuteNonQuery<U>(string procedure, U parameter);
        Task<List<T>> ExecuteQuery<T>(string procedure);
        Task<T> ExecuteSingleQuery<T, U>(string procedure, U parameter);
    }
    public class SQLDapperHelper: ISqlDapperHelper
    {
        public async Task<List<T>> ExecuteQuery<T>(string procedure)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(AppSettings.Settings.DBConnection))
                {
                    var data = await connection.QueryAsync<T>(procedure, commandType: CommandType.StoredProcedure);
                    return data.ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task ExecuteNonQuery<U>(string procedure, U parameter)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(AppSettings.Settings.DBConnection))
                {
                    await connection.ExecuteAsync(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> ExecuteSingleQuery<T, U>(string procedure, U parameter)
        {
            try
            {
                using (IDbConnection connection = new SqlConnection(AppSettings.Settings.DBConnection))
                {
                    return await connection.QuerySingleOrDefaultAsync<T>(procedure, parameter, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

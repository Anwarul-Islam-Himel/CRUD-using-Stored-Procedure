using Dapper;
using StoredProcedure.DtoModel;
using StoredProcedure.Repositories;
using System.Data;

namespace StoredProcedure.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllEmployee();
        Task<bool> InsertEmployee(EmployeeDto employee);
        Task<bool> DeleteEmployee(int employeeId);
        Task<bool> UpdateEmployee(EmployeeDto employee, int employeeId);
    }
    public class EmployeeService : IEmployeeService
    {
        private readonly ISqlDapperHelper _db;
        public EmployeeService(ISqlDapperHelper db)
        {
            _db = db;
        }

        public async Task<List<EmployeeDto>> GetAllEmployee()
        {
            try
            {
                return await _db.ExecuteQuery<EmployeeDto>("");
            }
            catch (Exception ex)
            {
                return new List<EmployeeDto>();
            }
        }

        public async Task<bool> InsertEmployee(EmployeeDto employee)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@FirstName", employee.FirstName, DbType.String);
            spParam.Add("@LastName", employee.LastName, DbType.String);
            spParam.Add("@Email", employee.Email, DbType.String);
            spParam.Add("@PhoneNumber", employee.PhoneNumber, DbType.String);
            spParam.Add("@Address", employee.Address, DbType.String);

            try
            {
                await _db.ExecuteNonQuery("Insert_Customer", spParam);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateEmployee(EmployeeDto employee, int employeeId)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@FirstName", employee.FirstName, DbType.String);
            spParam.Add("@LastName", employee.LastName, DbType.String);
            spParam.Add("@Email", employee.Email, DbType.String);
            spParam.Add("@PhoneNumber", employee.PhoneNumber, DbType.String);
            spParam.Add("@Address", employee.Address, DbType.String);
            spParam.Add("@EmployeeId", employeeId, DbType.Int32);

            try
            {
                await _db.ExecuteNonQuery("Update_Customer", spParam);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> DeleteEmployee(int employeeId)
        {
            var spParam = new DynamicParameters();
            spParam.Add("@EmployeeId", employeeId, DbType.Int32);

            try
            {
                await _db.ExecuteNonQuery("", spParam);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

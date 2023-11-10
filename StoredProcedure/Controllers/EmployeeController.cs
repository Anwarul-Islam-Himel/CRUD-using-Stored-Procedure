using Microsoft.AspNetCore.Mvc;
using StoredProcedure.DtoModel;
using StoredProcedure.Service;

namespace StoredProcedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee() =>
           Ok(await _employeeService.GetAllEmployee());

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto) =>
            Ok(await _employeeService.InsertEmployee(employeeDto));

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeDto employee, int id) =>
            Ok(await _employeeService.UpdateEmployee(employee, id));

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) =>
            Ok(await _employeeService.DeleteEmployee(id));
    }
}

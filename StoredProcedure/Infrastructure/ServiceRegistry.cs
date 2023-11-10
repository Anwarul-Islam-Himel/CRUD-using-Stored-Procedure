using StoredProcedure.Repositories;
using StoredProcedure.Service;

namespace StoredProcedure.Infrastructure
{
    public static class ServiceRegistry
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service)
        {
            service
                .AddScoped<ISqlDapperHelper, SQLDapperHelper>()
                .AddScoped<IEmployeeService, EmployeeService>();
            return service;
        }
    }
}

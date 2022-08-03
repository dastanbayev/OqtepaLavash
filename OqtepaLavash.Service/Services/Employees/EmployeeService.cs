
using AutoMapper;
using OqtepaLavash.Data.IRepositories;
using OqtepaLavash.Data.Repositories;
using OqtepaLavash.Domain.Entities.Employees;
using OqtepaLavash.Service.Commons.Interfaces;
using OqtepaLavash.Service.DTOs.CreationDtos;
using OqtepaLavash.Service.Mapper;
using System.Linq.Expressions;

namespace OqtepaLavash.Service.Services.Employees
{
    public class EmployeeService : IBaseService<Employee, EmployeeForCreation>
    {
#pragma warning disable

        private readonly IGenericRepository<Employee> repository;
        private readonly IMapper mapper;

        public EmployeeService()
        {
            repository = new GenericRepository<Employee>();
            mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }


        public Task<Employee> CreateAsync(EmployeeForCreation entityCreation)
        {
            Employee employee = mapper.Map<Employee>(entityCreation);

            return repository.CreateAsync(employee);
        }

        public Task<Boolean> DeleteAsync(Int64 id)
            => repository.DeleteAsync(employee => employee.Id == id);

        public async Task<IEnumerable<Employee>> GetAllAsync(Tuple<Int32, Int32>? pagenation = null, Expression<Func<Employee, Boolean>>? predicate = null)
            => pagenation is null ? repository.GetAll(predicate) : 
                                    repository.GetAll(predicate).Skip((pagenation.Item1 - 1) * pagenation.Item2).Take(pagenation.Item2);

        public Task<Employee> GetAsync(Int64 id)
            => repository.GetAsync(employee => employee.Id == id);

        public async Task<Employee> UpdateAsync(Int64 id, EmployeeForCreation entityCreation)
        {
            Employee employee = await repository.GetAsync(emp => emp.Id == id);

            if (employee is null)
                return null;

            employee = mapper.Map<Employee>(entityCreation);
            employee.UpdatedAt = DateTime.UtcNow;

            return await repository.UpdateAsync(employee);
        }
    }
}

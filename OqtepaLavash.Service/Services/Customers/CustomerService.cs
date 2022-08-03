
using AutoMapper;
using OqtepaLavash.Data.IRepositories;
using OqtepaLavash.Data.Repositories;
using OqtepaLavash.Domain.Entities.Customers;
using OqtepaLavash.Service.Commons.Interfaces;
using OqtepaLavash.Service.DTOs.CreationDtos;
using OqtepaLavash.Service.Mapper;
using System.Linq.Expressions;

namespace OqtepaLavash.Service.Services.Customers
{
    public class CustomerService : IBaseService<Customer, CustomerForCreation>
    {
#pragma warning disable

        private readonly IGenericRepository<Customer> repository;
        private readonly IMapper mapper;

        public CustomerService()
        {
            repository = new GenericRepository<Customer>();
            mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }

        public Task<Customer> CreateAsync(CustomerForCreation entityCreation)
        {
            Customer customer = mapper.Map<Customer>(entityCreation);

            return repository.CreateAsync(customer);
        }

        public Task<Boolean> DeleteAsync(Int64 id)
            => repository.DeleteAsync(cust => cust.Id == id);

        public async Task<IEnumerable<Customer>> GetAllAsync(Tuple<Int32, Int32>? pagenation = null, Expression<Func<Customer, Boolean>>? predicate = null)
            => pagenation is null ? repository.GetAll(predicate) : 
                   repository.GetAll(predicate).Skip((pagenation.Item1 - 1) * pagenation.Item2).Take(pagenation.Item2);

        public Task<Customer> GetAsync(Int64 id)
            => repository.GetAsync(cust => cust.Id == id);

        public async Task<Customer> UpdateAsync(Int64 id, CustomerForCreation entityCreation)
        {
            Customer customer = await repository.GetAsync(cust => cust.Id == id);

            if (customer is null)
                return null;

            customer = mapper.Map(entityCreation, customer);
            customer.UpdatedAt = DateTime.UtcNow;

            return await repository.UpdateAsync(customer);
        }
    }
}

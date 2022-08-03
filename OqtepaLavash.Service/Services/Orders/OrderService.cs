
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OqtepaLavash.Data.IRepositories;
using OqtepaLavash.Data.Repositories;
using OqtepaLavash.Domain.Entities.Orders;
using OqtepaLavash.Service.Commons.Interfaces;
using OqtepaLavash.Service.DTOs.CreationDtos;
using OqtepaLavash.Service.Mapper;
using System.Linq.Expressions;

namespace OqtepaLavash.Service.Services.Orders
{
    public class OrderService : IBaseService<Order, OrderForCreation>
    {
#pragma warning disable

        private readonly IGenericRepository<Order> repository;
        private readonly IMapper mapper;

        public OrderService()
        {
            this.repository = new GenericRepository<Order>();
            this.mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }
        public Task<Order> CreateAsync(OrderForCreation entityCreation)
        {
            Order order = mapper.Map<Order>(entityCreation);

            return repository.CreateAsync(order);
        }

        public Task<Boolean> DeleteAsync(Int64 id)
            => repository.DeleteAsync(order => order.Id == id);

        public async Task<IEnumerable<Order>> GetAllAsync(Tuple<Int32, Int32> pagenation = null, Expression<Func<Order, Boolean>> predicate = null)
            => pagenation is null ? repository.GetAll(predicate).Include("Customer").Include("Food").Include("Drink").Include("Employee").Include("Address") :
                                    repository.GetAll(predicate).Include("Customer").Include("Food").Include("Drink").Include("Employee").Include("Address")
                                    .Skip((pagenation.Item1 - 1) * pagenation.Item2).Take(pagenation.Item2);

        public async Task<Order> GetAsync(Int64 id)
            => await repository.GetAll(order => order.Id == id).Include("Customer").Include("Food").Include("Drink").Include("Employee").Include("Address").FirstOrDefaultAsync();

        public async Task<Order> UpdateAsync(Int64 id, OrderForCreation entityCreation)
        {
            Order order = await repository.GetAsync(ord => ord.Id == id);

            if (order is null)
                return null;

            order = mapper.Map<Order>(entityCreation);
            order.UpdatedAt = DateTime.UtcNow;

            return await repository.UpdateAsync(order);
        }
    }
}

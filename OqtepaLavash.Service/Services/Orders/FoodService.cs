
using AutoMapper;
using OqtepaLavash.Data.IRepositories;
using OqtepaLavash.Data.Repositories;
using OqtepaLavash.Domain.Entities.Orders;
using OqtepaLavash.Service.Commons.Interfaces;
using OqtepaLavash.Service.DTOs.CreationDtos;
using OqtepaLavash.Service.Mapper;
using System.Linq.Expressions;

namespace OqtepaLavash.Service.Services.Orders
{
    public class FoodService : IBaseService<Food, FoodForCreation>
    {
#pragma warning disable

        private readonly IGenericRepository<Food> repository;
        private readonly IMapper mapper;

        public FoodService()
        {
            this.repository = new GenericRepository<Food>();
            this.mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }

        public Task<Food> CreateAsync(FoodForCreation entityCreation)
        {
            Food food = mapper.Map<Food>(entityCreation);

            return repository.CreateAsync(food);
        }

        public Task<Boolean> DeleteAsync(Int64 id)
            => repository.DeleteAsync(food => food.Id == id);

        public async Task<IEnumerable<Food>> GetAllAsync(Tuple<Int32, Int32> pagenation = null, Expression<Func<Food, Boolean>> predicate = null)
            => pagenation is null ? repository.GetAll(predicate) :
                                    repository.GetAll(predicate).Skip((pagenation.Item1 - 1) * pagenation.Item2).Take(pagenation.Item2);

        public async Task<Food> GetAsync(Int64 id)
            => await repository.GetAsync(food => food.Id == id);

        public async Task<Food> UpdateAsync(Int64 id, FoodForCreation entityCreation)
        {
            Food food = await repository.GetAsync(food => food.Id == id);

            if (food is null)
                return null;

            food = mapper.Map<Food>(entityCreation);

            return await repository.UpdateAsync(food);
        }
    }
}


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
    public class DrinkService : IBaseService<Drink, DrinkForCreation>
    {
# pragma warning disable

        private readonly IGenericRepository<Drink> repository;
        private readonly IMapper mapper;

        public DrinkService()
        {
            this.repository = new GenericRepository<Drink>();
            this.mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
        }

        public Task<Drink> CreateAsync(DrinkForCreation entityCreation)
        {
            Drink drink = mapper.Map<Drink>(entityCreation);

            return repository.CreateAsync(drink);
        }

        public Task<Boolean> DeleteAsync(Int64 id)
            => repository.DeleteAsync(drink => drink.Id == id);

        public async Task<IEnumerable<Drink>> GetAllAsync(Tuple<Int32, Int32> pagenation = null, Expression<Func<Drink, Boolean>> predicate = null)
            => pagenation is null ? repository.GetAll(predicate) :
                                    repository.GetAll(predicate).Skip((pagenation.Item1 - 1) * pagenation.Item2).Take(pagenation.Item2);

        public Task<Drink> GetAsync(Int64 id)
            => repository.GetAsync(drink => drink.Id == id);

        public async Task<Drink> UpdateAsync(Int64 id, DrinkForCreation entityCreation)
        {
            Drink drink = await repository.GetAsync(drink => drink.Id == id);

            if (drink is null)
                return null;

            drink = mapper.Map<Drink>(entityCreation);

            return await repository.UpdateAsync(drink);
        }
    }
}

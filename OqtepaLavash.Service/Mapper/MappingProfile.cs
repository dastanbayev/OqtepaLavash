
using AutoMapper;
using OqtepaLavash.Domain.Entities.Customers;
using OqtepaLavash.Domain.Entities.Employees;
using OqtepaLavash.Domain.Entities.Orders;
using OqtepaLavash.Service.DTOs.CreationDtos;

namespace OqtepaLavash.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerForCreation>().ReverseMap();
            CreateMap<Employee, EmployeeForCreation>().ReverseMap();
            CreateMap<Food, FoodForCreation>().ReverseMap();
            CreateMap<Drink, DrinkForCreation>().ReverseMap();
            CreateMap<Order, OrderForCreation>().ReverseMap();
        }
    }
}

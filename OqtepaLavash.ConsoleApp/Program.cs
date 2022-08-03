using OqtepaLavash.Domain.Entities.Customers;
using OqtepaLavash.Domain.Entities.Orders;
using OqtepaLavash.Domain.Enums;
using OqtepaLavash.Service.Commons.Interfaces;
using OqtepaLavash.Service.DTOs.CreationDtos;
using OqtepaLavash.Service.Services.Customers;
using OqtepaLavash.Service.Services.Orders;

IBaseService<Order, OrderForCreation> service = new OrderService();

//await service.CreateAsync(new OrderForCreation()
//{
//    CustomerId = 4,
//    FoodId = 2,
//    FoodQuantity = 4,
//    DrinkId = 1,
//    DrinkQuantity = 56,
//    EmployeeId = 2,
//    PaymentType = Payment.Humo,
//    Address = new Address()
//    {
//        District = "Chilonzor",
//        Street = "Qatortol",
//        HomeNumber = "A453"
//    }
//});

//Customer res = await service.GetAsync(2);

IEnumerable<Order> res = await service.GetAllAsync();

foreach (var item in res)
{
    Console.WriteLine($"" +
        $"Customer name:    {item.Customer.Name}\n" +
        $"Customer phone:   {item.Customer.Phone}\n" +
        $"Ordered at:       {item.Customer.CreatedAt}\n" +
        $"Food:             {item.Food.Name}\n" +
        $"Price:            ${item.Food.Price}\n" +
        $"Quantity:         {item.FoodQuantity}\n" +
        $"Drink:            {item.Drink.Name}\n" +
        $"Price:            ${item.Drink.Price}\n" +
        $"Quantity:         {item.DrinkQuantity}\n" +
        $"Employee fName:   {item.Employee.Firstname}\n" +
        $"Employee lName:   {item.Employee.Lastname}\n" +
        $"Phone:            {item.Employee.Phone}\n" +
        $"Payment:          {item.PaymentType}\n" +
        $"District:         {item.Address.District}\n" +
        $"Street:           {item.Address.Street}\n" +
        $"Home number:      {item.Address.HomeNumber}\n"
        );
}

//var res = await service.UpdateAsync(4, new CustomerForCreation()
//{
//    Name = "Shrek",
//    Phone = "+998339586058"
//});

//var res = await service.DeleteAsync(13);


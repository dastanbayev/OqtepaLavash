
using OqtepaLavash.Domain.Enums;
using OqtepaLavash.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;

namespace OqtepaLavash.Service.DTOs.CreationDtos
{
    public class OrderForCreation
    {
#pragma warning disable
        
        [Required]
        public Int64 Id { get; set; }
        [Required]
        public Int64 CustomerId { get; set; }
        [Required]
        public Int64 EmployeeId { get; set; }
        [Required]
        public Int64 FoodId { get; set; }
        public Int32 FoodQuantity { get; set; }
        [Required]
        public Int64 DrinkId { get; set; }
        public Int32 DrinkQuantity { get; set; }
        [Required]
        public Payment PaymentType { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}

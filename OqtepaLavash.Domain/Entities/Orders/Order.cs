using OqtepaLavash.Domain.Entities.Customers;
using OqtepaLavash.Domain.Entities.Employees;
using OqtepaLavash.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OqtepaLavash.Domain.Entities.Orders
{
    public class Order
    {
#pragma warning disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        public Int64 CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public Int64 FoodId { get; set; }

        [ForeignKey(nameof(FoodId))]
        public Food Food { get; set; }

        public Int16? FoodQuantity { get; set; }

        public Int64 DrinkId { get; set; }

        [ForeignKey(nameof(DrinkId))]
        public Drink Drink { get; set; }

        public Int16? DrinkQuantity { get; set; }

        public Int64 EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public Payment PaymentType { get; set; }

        public Int64 AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

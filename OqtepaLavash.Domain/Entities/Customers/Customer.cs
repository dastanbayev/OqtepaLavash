

using OqtepaLavash.Domain.Entities.Orders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OqtepaLavash.Domain.Entities.Customers
{
    public class Customer
    {
#pragma warning disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        ICollection<Order> Orders { get; set; }
    }
}

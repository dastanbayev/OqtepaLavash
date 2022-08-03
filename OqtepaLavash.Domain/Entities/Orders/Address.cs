

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OqtepaLavash.Domain.Entities.Orders
{
    public class Address
    {
#pragma warning disable
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        public String District { get; set; }
        public String Street { get; set; }
        public String HomeNumber { get; set; }
    }
}

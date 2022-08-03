
using System.ComponentModel.DataAnnotations;

namespace OqtepaLavash.Service.DTOs.CreationDtos
{
    public class FoodForCreation
    {
#pragma warning disable

        [Required, MaxLength(35)]
        public String Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
    }
}

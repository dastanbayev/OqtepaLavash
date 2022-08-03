

using System.ComponentModel.DataAnnotations;

namespace OqtepaLavash.Service.DTOs.CreationDtos
{
#pragma warning disable
    public class DrinkForCreation
    {
        [Required, MaxLength(35)]
        public String Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
    }
}

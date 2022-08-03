
using System.ComponentModel.DataAnnotations;

namespace OqtepaLavash.Service.DTOs.CreationDtos
{
    public class CustomerForCreation
    {
#pragma warning disable

        [Required, MaxLength(40)]
        public String Name { get; set; }
        [Required, Phone]
        public String Phone { get; set; }
    }
}

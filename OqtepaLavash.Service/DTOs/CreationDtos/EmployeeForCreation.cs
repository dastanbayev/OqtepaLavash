

using System.ComponentModel.DataAnnotations;

namespace OqtepaLavash.Service.DTOs.CreationDtos
{
    public class EmployeeForCreation
    {
#pragma warning disable

        [Required, MaxLength(40)]
        public String Firstname { get; set; }
        [Required, MaxLength(40)]
        public String Lastname { get; set; }
        [Required, Phone]
        public String Phone { get; set; }
        [Required, MaxLength(9)]
        public String PassportSeriaNumber { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OqtepaLavash.Domain.Entities.Employees
{
    public class Employee
    {
#pragma warning disable

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [Required]
        public String Firstname { get; set; }
        [Required]
        public String Lastname { get; set; }
        [Required]
        public String Phone { get; set; }
        [Required]
        public String PassportSeriaNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}

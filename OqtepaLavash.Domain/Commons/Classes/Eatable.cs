

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OqtepaLavash.Domain.Commons.Classes
{
    public class Eatable
    {
#pragma warning disable

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
    }
}

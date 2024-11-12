using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jornada.API.Models
{
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

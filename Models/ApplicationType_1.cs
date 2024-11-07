using System.ComponentModel.DataAnnotations;

namespace Rocky_1.Models
{
    public class ApplicationType_1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

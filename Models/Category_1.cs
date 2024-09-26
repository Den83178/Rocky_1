using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Rocky_1.Models
{
    public class Category_1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Display Orded must be great than 0")]
        public int DisplayOrder { get; set; }

    }
}

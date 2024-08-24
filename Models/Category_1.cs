using System.ComponentModel.DataAnnotations;

namespace Rocky_1.Models
{
    public class Category_1
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

    }
}

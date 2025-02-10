using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rocky_1.Models
{
    public class Product_1
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDesc { get; set; }

        public string? Description { get; set; }

        [Range ( 1, int.MaxValue )]
        public double Price { get; set; }

        public string? Image {  get; set; }


        [Display(Name = "Category Type")]
        public int Category_1_Id { get; set; }

        [ForeignKey("Category_1_Id")]
        public virtual Category_1? Category_1 { get; set; }


        [Display(Name = "Application Type")]
        public int ApplicationType_1_Id { get; set; }

        [ForeignKey("ApplicationType_1_Id")]
        public virtual ApplicationType_1? ApplicationType_1 { get; set; }
    }
}

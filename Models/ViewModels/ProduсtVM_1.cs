using Microsoft.AspNetCore.Mvc.Rendering;


namespace Rocky_1.Models.ViewModels
{
    public class ProductVM_1
    {
        public IEnumerable<SelectListItem>? CategorySelectList_1 { get; set; }
        public IEnumerable<SelectListItem>? ApplicationTypeSelectList_1 { get; set; }

        public Product_1 Product_1 { get; set; }
    }
}

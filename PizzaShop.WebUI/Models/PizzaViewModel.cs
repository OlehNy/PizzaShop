using System.ComponentModel.DataAnnotations;

namespace PizzaShop.WebUI.Models
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [Display(Name = "PizzaName")]
        public string? Name { get; set; }
        [Display(Name = "PizzaDescription")]
        public string? Description{ get; set; }
        [Display(Name = "PizzaPrice")]
        public decimal Price{ get; set; }
        public string? ImageUrl { get; set; }
    }
}

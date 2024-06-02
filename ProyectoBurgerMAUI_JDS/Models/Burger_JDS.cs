using System.ComponentModel.DataAnnotations;

namespace ProyectoBurgerMAUI_JDS.Models
{
    public class Burger_JDS
    {
        [Key]
        public int burgerId_JDS { get; set; }
        public string? name_JDS { get; set; }
        public bool withCheese_JDS { get; set; }
        public decimal precio_JDS { get; set; }
        public List<object>? promo_JDS { get; set; }
    }
}

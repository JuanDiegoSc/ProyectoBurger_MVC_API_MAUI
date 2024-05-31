using System.ComponentModel.DataAnnotations;

namespace ProyectoBurger_MVC_API_MAUI.Models
{
    public class Burger_JDS
    {
        [Key]
        public int BurgerId_JDS { get; set; }
        [Required]
        public string? Name_JDS { get; set; }
        public bool WithCheese_JDS { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Precio_JDS { get; set; }

        public List<Promo_JDS>? Promo_JDS { get; set; }


        public class VerificarRango : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                if ((decimal)value < 1 || (decimal)value > 20)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }
}

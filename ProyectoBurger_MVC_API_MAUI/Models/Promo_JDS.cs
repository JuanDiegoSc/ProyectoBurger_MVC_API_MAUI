using System.ComponentModel.DataAnnotations;

namespace ProyectoBurger_MVC_API_MAUI.Models
{
    public class Promo_JDS
    {
        [Key]
        public int PromoId_JDS { get; set; }

        [Required]
        public string? Descripcion_JDS { get; set; }

        [Required]
        public DateTime FechaPromo_JDS { get; set; }

        public int BurgerId_JDS { get; set; } //clave foranea

        public Burger_JDS? Burger_JDS { get; set; } //definición de propiedad
    }
}

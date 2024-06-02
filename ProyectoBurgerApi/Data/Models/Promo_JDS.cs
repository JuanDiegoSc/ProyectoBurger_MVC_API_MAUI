using System.ComponentModel.DataAnnotations;

namespace ProyectoBurgerApi.Data.Models;

public partial class Promo_JDS
{
    [Key]
    public int PromoId_JDS { get; set; }

    public string Descripcion_JDS { get; set; } = null!;

    public DateTime FechaPromo_JDS { get; set; }

    public int BurgerId_JDS { get; set; }

    public virtual Burger_JDS? Burger_JDS { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using ProyectoBurgerApi.Data;

namespace ProyectoBurgerApi.Data.Models;

public partial class Burger_JDS
{
    [Key]
    public int BurgerId_JDS { get; set; }

    public string Name_JDS { get; set; } = null!;

    public bool WithCheese_JDS { get; set; }

    public decimal Precio_JDS { get; set; }

    public virtual ICollection<Promo_JDS> Promo_JDS { get; set; } = new List<Promo_JDS>();
}


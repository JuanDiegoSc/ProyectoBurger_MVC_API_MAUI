using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoBurgerApi.Data.Models;

namespace ProyectoBurgerApi.Data
{
    public class ProyectoBurgerApiContext : DbContext
    {
        public ProyectoBurgerApiContext (DbContextOptions<ProyectoBurgerApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoBurgerApi.Data.Models.Burger_JDS> Burger_JDS { get; set; } = default!;
        public DbSet<ProyectoBurgerApi.Data.Models.Promo_JDS> Promo_JDS { get; set; } = default!;
    }
}

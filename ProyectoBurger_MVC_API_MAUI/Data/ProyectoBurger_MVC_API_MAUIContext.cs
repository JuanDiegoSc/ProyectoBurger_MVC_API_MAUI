using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoBurger_MVC_API_MAUI.Models;

namespace ProyectoBurger_MVC_API_MAUI.Data
{
    public class ProyectoBurger_MVC_API_MAUIContext : DbContext
    {
        public ProyectoBurger_MVC_API_MAUIContext (DbContextOptions<ProyectoBurger_MVC_API_MAUIContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoBurger_MVC_API_MAUI.Models.Burger_JDS> Burger_JDS { get; set; } = default!;
        public DbSet<ProyectoBurger_MVC_API_MAUI.Models.Promo_JDS> Promo_JDS { get; set; } = default!;
    }
}

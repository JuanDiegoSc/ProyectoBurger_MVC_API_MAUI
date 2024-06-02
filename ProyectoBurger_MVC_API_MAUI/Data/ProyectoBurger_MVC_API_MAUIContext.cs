using Microsoft.EntityFrameworkCore;

namespace ProyectoBurger_MVC_API_MAUI.Data
{
    public class ProyectoBurger_MVC_API_MAUIContext : DbContext
    {
        public ProyectoBurger_MVC_API_MAUIContext(DbContextOptions<ProyectoBurger_MVC_API_MAUIContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoBurger_MVC_API_MAUI.Models.Burger_JDS> Burger_JDS { get; set; } = default!;
        public DbSet<ProyectoBurger_MVC_API_MAUI.Models.Promo_JDS> Promo_JDS { get; set; } = default!;
    }
}

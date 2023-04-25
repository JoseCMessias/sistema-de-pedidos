using Microsoft.EntityFrameworkCore;
using Sistema_Pedidos.Domain;

namespace Sistema_Pedidos.Data
{
   public class ApplicationContext : DbContext
   {
      DbSet<Pedido> pedidos { get; set; }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
         optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqlocaldb;Initial Catalog=Sistema_Pedidos; Integrated Security=true");
      }
   }
}
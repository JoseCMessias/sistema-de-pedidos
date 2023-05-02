using Microsoft.EntityFrameworkCore;
using Sistema_Pedidos.Configurations;
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

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfiguration(new ClienteConfiguration());
         modelBuilder.ApplyConfiguration(new PedidoConfiguration());
         modelBuilder.ApplyConfiguration(new PedidoItemConfiguration());
         modelBuilder.ApplyConfiguration(new ProdutoConfiguration());

         // Com isso não precisaria informa cada arquivo de mapeando do banco de dados a cima. Ele puxa tudo de uma vez
         // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
      }
   }
}
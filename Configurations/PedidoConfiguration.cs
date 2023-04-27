using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Pedidos.Domain;

namespace Sistema_Pedidos.Configurations
{
   public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
   {
      public void Configure(EntityTypeBuilder<Pedido> builder)
      {
         builder.ToTable("Pedido");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.Status).HasConversion<string>();
         builder.Property(p => p.Observacao).HasColumnType("CHAR(52)").IsRequired();
      }
   }
}
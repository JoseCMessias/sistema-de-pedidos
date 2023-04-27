using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Pedidos.Domain;

namespace Sistema_Pedidos.Configurations
{
   public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
   {
      public void Configure(EntityTypeBuilder<PedidoItem> builder)
      {
         builder.ToTable("PedidoItem");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
         builder.Property(p => p.Valor).IsRequired();
         builder.Property(p => p.Desconto).IsRequired();
      }
   }
}
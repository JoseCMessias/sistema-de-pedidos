using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Pedidos.Domain;

namespace Sistema_Pedidos.Configurations
{
   public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
   {
      public void Configure(EntityTypeBuilder<Produto> builder)
      {
         builder.ToTable("Produto");
         builder.HasKey(p => p.Id);
         builder.Property(p => p.CodigoBarra).HasColumnType("VARCHAR(80)").IsRequired();
         builder.Property(p => p.Descricao).HasColumnType("CHAR(11)").IsRequired();
         builder.Property(p => p.Valor).IsRequired();

         //builder.HasKey(p => p.Itens).WithOne(p => p.Pedido).OnDelete(DeleteBehavior.Cascade);
      }
   }
}
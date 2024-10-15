using LojaDoSeuManoel.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("TB_PEDIDOS");

            builder.HasKey(p => p.PedidoId);

            builder.Property(p => p.PedidoId).HasColumnName("ID");
            
            builder.HasMany(p => p.Produtos);
        }
    }
}

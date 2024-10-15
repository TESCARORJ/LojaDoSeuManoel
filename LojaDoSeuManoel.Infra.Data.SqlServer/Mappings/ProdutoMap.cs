using LojaDoSeuManoel.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("TB_PRODUTOS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.ProdutoId)
                .HasColumnName("ProdutoId")
                .HasColumnType("varchar(100)")
                .IsRequired();

    
        }
    }
}

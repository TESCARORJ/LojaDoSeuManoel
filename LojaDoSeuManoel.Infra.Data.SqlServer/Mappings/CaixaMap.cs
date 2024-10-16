using LojaDoSeuManoel.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Mappings
{
    public class CaixaMap : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.ToTable("TB_CAIXA");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.CaixaId)
                .HasColumnName("CaixaId")
                .HasColumnType("varchar(100)")
                .IsRequired();

    
        }
    }
}

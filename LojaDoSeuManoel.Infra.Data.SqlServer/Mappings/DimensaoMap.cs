using LojaDoSeuManoel.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Mappings
{
    public class DimensaoMap : IEntityTypeConfiguration<Dimensao>
    {
        public void Configure(EntityTypeBuilder<Dimensao> builder)
        {
            builder.ToTable("TB_Dimensao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");
            builder.Property(x => x.Altura)
                .HasColumnName("ALTURA")
                .HasColumnType("FLOAT")
                .IsRequired();
            builder.Property(x => x.Largura)
                .HasColumnName("LARGURA")
                .HasColumnType("FLOAT")
                .IsRequired();
            builder.Property(x => x.Comprimento)
                .HasColumnName("COMPRIMENTO")
                .HasColumnType("FLOAT")
                .IsRequired();
        }
    }

}

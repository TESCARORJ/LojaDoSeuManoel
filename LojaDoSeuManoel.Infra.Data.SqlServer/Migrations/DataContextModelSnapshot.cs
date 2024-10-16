﻿// <auto-generated />
using System;
using LojaDoSeuManoel.Infra.Data.SqlServer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CaixaId")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("CaixaId");

                    b.Property<int>("DimensaoId")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PedidoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DimensaoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("TB_CAIXA", (string)null);
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Dimensao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Altura")
                        .HasColumnType("FLOAT")
                        .HasColumnName("ALTURA");

                    b.Property<double>("Comprimento")
                        .HasColumnType("FLOAT")
                        .HasColumnName("COMPRIMENTO");

                    b.Property<double>("Largura")
                        .HasColumnType("FLOAT")
                        .HasColumnName("LARGURA");

                    b.HasKey("Id");

                    b.ToTable("TB_Dimensao", (string)null);
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Pedido", b =>
                {
                    b.Property<long>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PedidoId"));

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PedidoId");

                    b.ToTable("TB_PEDIDO", (string)null);
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CaixaId")
                        .HasColumnType("int");

                    b.Property<int?>("DimensaoId")
                        .HasColumnType("int");

                    b.Property<long?>("PedidoId")
                        .HasColumnType("bigint");

                    b.Property<string>("ProdutoId")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ProdutoId");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.HasIndex("DimensaoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("TB_PRODUTO", (string)null);
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Caixa", b =>
                {
                    b.HasOne("LojaDoSeuManoel.Domain.Entites.Dimensao", "Dimensao")
                        .WithMany()
                        .HasForeignKey("DimensaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaDoSeuManoel.Domain.Entites.Pedido", null)
                        .WithMany("Caixas")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Dimensao");
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Produto", b =>
                {
                    b.HasOne("LojaDoSeuManoel.Domain.Entites.Caixa", null)
                        .WithMany("Produtos")
                        .HasForeignKey("CaixaId");

                    b.HasOne("LojaDoSeuManoel.Domain.Entites.Dimensao", "Dimensao")
                        .WithMany()
                        .HasForeignKey("DimensaoId");

                    b.HasOne("LojaDoSeuManoel.Domain.Entites.Pedido", null)
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId");

                    b.Navigation("Dimensao");
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Caixa", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("LojaDoSeuManoel.Domain.Entites.Pedido", b =>
                {
                    b.Navigation("Caixas");

                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}

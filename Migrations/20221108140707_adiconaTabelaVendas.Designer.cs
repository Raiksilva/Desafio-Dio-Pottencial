// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Payment_api.Context;

#nullable disable

namespace Payment_api.Migrations
{
    [DbContext(typeof(PagamentoApiContext))]
    [Migration("20221108140707_adiconaTabelaVendas")]
    partial class adiconaTabelaVendas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Payment_api.Models.CompraItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("IDVendas")
                        .HasColumnType("int");

                    b.Property<int>("IDVendedor")
                        .HasColumnType("int");

                    b.Property<int?>("VendaID")
                        .HasColumnType("int");

                    b.Property<int?>("VendedorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("VendaID");

                    b.HasIndex("VendedorID");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Payment_api.Models.VendaItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDVendedor")
                        .HasColumnType("int");

                    b.Property<int>("StatusItemVenda")
                        .HasColumnType("int");

                    b.Property<string>("item")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("vendaItem");
                });

            modelBuilder.Entity("Payment_api.Models.Vendedor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("Payment_api.Models.CompraItem", b =>
                {
                    b.HasOne("Payment_api.Models.VendaItem", "Venda")
                        .WithMany()
                        .HasForeignKey("VendaID");

                    b.HasOne("Payment_api.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorID");

                    b.Navigation("Venda");

                    b.Navigation("Vendedor");
                });
#pragma warning restore 612, 618
        }
    }
}

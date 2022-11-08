using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment_api.Migrations
{
    public partial class adiconaTabelaVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vendaItem",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVendedor = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusItemVenda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vendaItem", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVendas = table.Column<int>(type: "int", nullable: false),
                    IDVendedor = table.Column<int>(type: "int", nullable: false),
                    VendaID = table.Column<int>(type: "int", nullable: true),
                    VendedorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Compra_vendaItem_VendaID",
                        column: x => x.VendaID,
                        principalTable: "vendaItem",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Compra_Vendedor_VendedorID",
                        column: x => x.VendedorID,
                        principalTable: "Vendedor",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_VendaID",
                table: "Compra",
                column: "VendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_VendedorID",
                table: "Compra",
                column: "VendedorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "vendaItem");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}

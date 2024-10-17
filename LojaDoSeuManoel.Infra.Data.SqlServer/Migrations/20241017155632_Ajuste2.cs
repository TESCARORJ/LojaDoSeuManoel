using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "TB_PEDIDO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "TB_PEDIDO");
        }
    }
}

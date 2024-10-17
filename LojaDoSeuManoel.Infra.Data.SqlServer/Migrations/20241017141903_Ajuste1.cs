using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class Ajuste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CAIXA_TB_Dimensao_DimensaoId",
                table: "TB_CAIXA");

            migrationBuilder.AddColumn<int>(
                name: "CaixaId",
                table: "TB_PRODUTO",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DimensaoId",
                table: "TB_CAIXA",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "TB_CAIXA",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_CaixaId",
                table: "TB_PRODUTO",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CAIXA_PedidoId",
                table: "TB_CAIXA",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CAIXA_TB_Dimensao_DimensaoId",
                table: "TB_CAIXA",
                column: "DimensaoId",
                principalTable: "TB_Dimensao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CAIXA_TB_PEDIDO_PedidoId",
                table: "TB_CAIXA",
                column: "PedidoId",
                principalTable: "TB_PEDIDO",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_PRODUTO_TB_CAIXA_CaixaId",
                table: "TB_PRODUTO",
                column: "CaixaId",
                principalTable: "TB_CAIXA",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_CAIXA_TB_Dimensao_DimensaoId",
                table: "TB_CAIXA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_CAIXA_TB_PEDIDO_PedidoId",
                table: "TB_CAIXA");

            migrationBuilder.DropForeignKey(
                name: "FK_TB_PRODUTO_TB_CAIXA_CaixaId",
                table: "TB_PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_TB_PRODUTO_CaixaId",
                table: "TB_PRODUTO");

            migrationBuilder.DropIndex(
                name: "IX_TB_CAIXA_PedidoId",
                table: "TB_CAIXA");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "TB_PRODUTO");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "TB_CAIXA");

            migrationBuilder.AlterColumn<int>(
                name: "DimensaoId",
                table: "TB_CAIXA",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_CAIXA_TB_Dimensao_DimensaoId",
                table: "TB_CAIXA",
                column: "DimensaoId",
                principalTable: "TB_Dimensao",
                principalColumn: "ID");
        }
    }
}

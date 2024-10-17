using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaDoSeuManoel.Infra.Data.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class InicioProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Dimensao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ALTURA = table.Column<double>(type: "FLOAT", nullable: false),
                    LARGURA = table.Column<double>(type: "FLOAT", nullable: false),
                    COMPRIMENTO = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Dimensao", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_CAIXA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaixaId = table.Column<string>(type: "varchar(100)", nullable: false),
                    DimensaoId = table.Column<int>(type: "int", nullable: true),
                    Observacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CAIXA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CAIXA_TB_Dimensao_DimensaoId",
                        column: x => x.DimensaoId,
                        principalTable: "TB_Dimensao",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<string>(type: "varchar(100)", nullable: false),
                    DimensaoId = table.Column<int>(type: "int", nullable: true),
                    PedidoId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_Dimensao_DimensaoId",
                        column: x => x.DimensaoId,
                        principalTable: "TB_Dimensao",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_TB_PRODUTO_TB_PEDIDO_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "TB_PEDIDO",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_CAIXA_DimensaoId",
                table: "TB_CAIXA",
                column: "DimensaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_DimensaoId",
                table: "TB_PRODUTO",
                column: "DimensaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUTO_PedidoId",
                table: "TB_PRODUTO",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CAIXA");

            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_Dimensao");

            migrationBuilder.DropTable(
                name: "TB_PEDIDO");
        }
    }
}

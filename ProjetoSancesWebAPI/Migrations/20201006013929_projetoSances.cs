using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSancesWebAPI.Migrations
{
    public partial class projetoSances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    ValorUni = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    Situacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PedidoProduto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(nullable: false),
                    Desconto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoProduto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Cpf", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "08545685238", "Marta", 33225555 },
                    { 2, "14785236998", "Paula", 3354288 },
                    { 3, "98745632114", "Laura", 55668899 },
                    { 4, "95184763252", "Luiza", 6565659 },
                    { 5, "96587412365", "Lucas", 565685415 },
                    { 6, "85274196385", "Pedro", 456454545 },
                    { 7, "32569874196", "Paulo", 987451852 }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "Descricao", "ValorUni" },
                values: new object[,]
                {
                    { 1, "Filtro Óleo", 12.25 },
                    { 2, "Embreagem", 145.59999999999999 },
                    { 3, "Pastilha Freio", 74.989999999999995 },
                    { 4, "Óleo Motor", 16.800000000000001 },
                    { 5, "Filtro Ar", 33.0 },
                    { 6, "Amortecedor", 120.65000000000001 },
                    { 7, "Mão de Obra", 80.0 }
                });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId", "Data", "Situacao", "ValorTotal" },
                values: new object[] { 2, 1, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analise", 0.0 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId", "Data", "Situacao", "ValorTotal" },
                values: new object[] { 1, 5, new DateTime(2020, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analise", 0.0 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "ClienteId", "Data", "Situacao", "ValorTotal" },
                values: new object[] { 3, 7, new DateTime(2020, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Analise", 0.0 });

            migrationBuilder.InsertData(
                table: "PedidoProduto",
                columns: new[] { "Id", "Desconto", "PedidoId", "ProdutoId", "Quantidade" },
                values: new object[,]
                {
                    { 3, 0.0, 2, 3, 1 },
                    { 4, 0.0, 2, 6, 2 },
                    { 5, 0.0, 2, 7, 2 },
                    { 1, 0.0, 1, 1, 1 },
                    { 2, 0.0, 1, 4, 5 },
                    { 6, 0.0, 3, 5, 1 },
                    { 7, 0.0, 3, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_PedidoId",
                table: "PedidoProduto",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoProduto_ProdutoId",
                table: "PedidoProduto",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidoProduto");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

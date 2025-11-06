using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiveMotors.Migrations
{
    /// <inheritdoc />
    public partial class AddMudan01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbFaleComVendedor",
                columns: table => new
                {
                    FaleComVendedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Assunto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFaleComVendedor", x => x.FaleComVendedorId);
                });

            migrationBuilder.CreateTable(
                name: "tbFormaDePagamento",
                columns: table => new
                {
                    FormaDePagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParcelasMax = table.Column<int>(type: "int", nullable: false),
                    JurosMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescontoAVista = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbFormaDePagamento", x => x.FormaDePagamentoId);
                });

            migrationBuilder.CreateTable(
                name: "tbVeiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagemsVeiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estoque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVeiculo", x => x.VeiculoId);
                });

            migrationBuilder.CreateTable(
                name: "tbCliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CpfCnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPessoa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbCliente", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_tbCliente_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tbEstoquePedido",
                columns: table => new
                {
                    EstoquePedidoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantidadeDisponivel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEstoquePedido", x => x.EstoquePedidoId);
                    table.ForeignKey(
                        name: "FK_tbEstoquePedido_tbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tbVeiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbAgendamento",
                columns: table => new
                {
                    AgendamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observação = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbAgendamento", x => x.AgendamentoId);
                    table.ForeignKey(
                        name: "FK_tbAgendamento_tbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbCliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbAgendamento_tbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tbVeiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbVenda",
                columns: table => new
                {
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormaDePagamentoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPrevistaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbVenda", x => x.VendaId);
                    table.ForeignKey(
                        name: "FK_tbVenda_tbCliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "tbCliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbVenda_tbFormaDePagamento_FormaDePagamentoId",
                        column: x => x.FormaDePagamentoId,
                        principalTable: "tbFormaDePagamento",
                        principalColumn: "FormaDePagamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbVenda_tbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tbVeiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbItemDaVenda",
                columns: table => new
                {
                    ItemDaVendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VendaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbItemDaVenda", x => x.ItemDaVendaId);
                    table.ForeignKey(
                        name: "FK_tbItemDaVenda_tbVeiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tbVeiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbItemDaVenda_tbVenda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "tbVenda",
                        principalColumn: "VendaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbAgendamento_ClienteId",
                table: "tbAgendamento",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbAgendamento_VeiculoId",
                table: "tbAgendamento",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbCliente_UserId",
                table: "tbCliente",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbEstoquePedido_VeiculoId",
                table: "tbEstoquePedido",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbItemDaVenda_VeiculoId",
                table: "tbItemDaVenda",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbItemDaVenda_VendaId",
                table: "tbItemDaVenda",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVenda_ClienteId",
                table: "tbVenda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVenda_FormaDePagamentoId",
                table: "tbVenda",
                column: "FormaDePagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbVenda_VeiculoId",
                table: "tbVenda",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbAgendamento");

            migrationBuilder.DropTable(
                name: "tbEstoquePedido");

            migrationBuilder.DropTable(
                name: "tbFaleComVendedor");

            migrationBuilder.DropTable(
                name: "tbItemDaVenda");

            migrationBuilder.DropTable(
                name: "tbVenda");

            migrationBuilder.DropTable(
                name: "tbCliente");

            migrationBuilder.DropTable(
                name: "tbFormaDePagamento");

            migrationBuilder.DropTable(
                name: "tbVeiculo");

            migrationBuilder.DropTable(
                name: "ApplicationUser");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceDDD.Infrastructure.Migrations
{
    public partial class TesteAuditoria2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Produtos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Produtos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracaoId",
                table: "Produtos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCriacaoId",
                table: "Produtos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioExclusaoId",
                table: "Produtos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracao",
                table: "Compras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Compras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "Compras",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioAlteracaoId",
                table: "Compras",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCriacaoId",
                table: "Compras",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioExclusaoId",
                table: "Compras",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Cep = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    TelefoneFixo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataAlteracao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioCriacaoId = table.Column<string>(type: "varchar(100)", nullable: true),
                    UsuarioAlteracaoId = table.Column<string>(type: "varchar(100)", nullable: true),
                    UsuarioExclusaoId = table.Column<string>(type: "varchar(100)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(100)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(100)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_AspNetUsers_UsuarioAlteracaoId",
                        column: x => x.UsuarioAlteracaoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_AspNetUsers_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_AspNetUsers_UsuarioExclusaoId",
                        column: x => x.UsuarioExclusaoId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioAlteracaoId",
                table: "Produtos",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioCriacaoId",
                table: "Produtos",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_UsuarioExclusaoId",
                table: "Produtos",
                column: "UsuarioExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioAlteracaoId",
                table: "Compras",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioCriacaoId",
                table: "Compras",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compras_UsuarioExclusaoId",
                table: "Compras",
                column: "UsuarioExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioAlteracaoId",
                table: "Usuario",
                column: "UsuarioAlteracaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioCriacaoId",
                table: "Usuario",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioExclusaoId",
                table: "Usuario",
                column: "UsuarioExclusaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuario_UsuarioAlteracaoId",
                table: "Compras",
                column: "UsuarioAlteracaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuario_UsuarioCriacaoId",
                table: "Compras",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Usuario_UsuarioExclusaoId",
                table: "Compras",
                column: "UsuarioExclusaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuario_UsuarioAlteracaoId",
                table: "Produtos",
                column: "UsuarioAlteracaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuario_UsuarioCriacaoId",
                table: "Produtos",
                column: "UsuarioCriacaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Usuario_UsuarioExclusaoId",
                table: "Produtos",
                column: "UsuarioExclusaoId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuario_UsuarioAlteracaoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuario_UsuarioCriacaoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Usuario_UsuarioExclusaoId",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuario_UsuarioAlteracaoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuario_UsuarioCriacaoId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Usuario_UsuarioExclusaoId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioAlteracaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioCriacaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_UsuarioExclusaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioAlteracaoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioCriacaoId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_UsuarioExclusaoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioCriacaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "UsuarioExclusaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "DataAlteracao",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuarioAlteracaoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuarioCriacaoId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "UsuarioExclusaoId",
                table: "Compras");
        }
    }
}

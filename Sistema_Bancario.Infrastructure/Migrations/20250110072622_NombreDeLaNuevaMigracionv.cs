using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema_Bancario.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NombreDeLaNuevaMigracionv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaDeNacimiento = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim<string>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransacciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuentaBancarias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroDeCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuentaBancarias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuentaBancarias_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AplicationUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_AplicationUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AplicationUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaTransaccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CuentaBancariaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TipoTransaccionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_CuentaBancarias_CuentaBancariaId",
                        column: x => x.CuentaBancariaId,
                        principalTable: "CuentaBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacciones_TipoTransacciones_TipoTransaccionId",
                        column: x => x.TipoTransaccionId,
                        principalTable: "TipoTransacciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6", null, "Administrador", "Administrador" },
                    { "b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7", null, "CajeroVentanilla", "CajeroVentanilla" }
                });

            migrationBuilder.InsertData(
                table: "IdentityRoleClaim<string>",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "POLICIES", "LEER_DEPOSITO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 2, "POLICIES", "LEER_DEPOSITO", "b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7" },
                    { 3, "POLICIES", "LEER_RETIRO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 4, "POLICIES", "LEER_RETIRO", "b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7" },
                    { 5, "POLICIES", "RETIRO", "b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7" },
                    { 6, "POLICIES", "RETIRO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 7, "POLICIES", "DEPOSITO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 8, "POLICIES", "DEPOSITO", "b2c3d4e5-f6a7-48b9-0c1d-e2f3a4b5c6a7" },
                    { 9, "POLICIES", "LEER_ROL", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 10, "POLICIES", "ELIMINAR_ROL", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 11, "POLICIES", "MODIFICAR_ROL", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 12, "POLICIES", "REGISTRAR_ROL", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 13, "POLICIES", "REGISTRAR_USUARIO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 14, "POLICIES", "MODIFICAR_USUARIO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 15, "POLICIES", "ELIMINAR_USUARIO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 16, "POLICIES", "LEER_USUARIO", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 17, "POLICIES", "REGISTRAR_CUENTA", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" },
                    { 18, "POLICIES", "LEER_CUENTA", "a1b2c3d4-e5f6-47a8-9b0c-d1e2f3a4b5c6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AplicationUsers_RoleId",
                table: "AplicationUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaBancarias_ClienteId",
                table: "CuentaBancarias",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CuentaBancariaId",
                table: "Transacciones",
                column: "CuentaBancariaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_TipoTransaccionId",
                table: "Transacciones",
                column: "TipoTransaccionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicationUsers");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim<string>");

            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CuentaBancarias");

            migrationBuilder.DropTable(
                name: "TipoTransacciones");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDemoAPI.Migrations
{
    /// <inheritdoc />
    public partial class AutenticationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Personas",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Personas",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "correo",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "correo",
                table: "Personas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAIS.Infra.Migrations
{
    /// <inheritdoc />
    public partial class DeclarationChecked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeclarationChecked",
                table: "Applicants",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclarationChecked",
                table: "Applicants");
        }
    }
}

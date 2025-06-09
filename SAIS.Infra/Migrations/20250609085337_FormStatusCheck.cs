using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SAIS.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FormStatusCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataEnteredBy",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormStatus",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEnteredBy",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "FormStatus",
                table: "Applicants");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sem13.Migrations
{
    /// <inheritdoc />
    public partial class v1_campoactive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Grades",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Courses");
        }
    }
}

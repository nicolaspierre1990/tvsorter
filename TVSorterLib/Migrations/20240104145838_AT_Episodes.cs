using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSorter.Migrations
{
    /// <inheritdoc />
    public partial class AT_Episodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Episodes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Episodes");
        }
    }
}

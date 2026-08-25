using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSorter.Migrations
{
    /// <inheritdoc />
    public partial class AddShowDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Overview",
                table: "TvShows",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "TvShows",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overview",
                table: "TvShows");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "TvShows");
        }
    }
}

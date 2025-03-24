using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TVSorter.Migrations;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Setting",
            columns: table => new
            {
                SettingName = table.Column<string>(type: "TEXT", nullable: false),
                SettingValue = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Setting", x => x.SettingName);
            });

        migrationBuilder.CreateTable(
            name: "TvShows",
            columns: table => new
            {
                TvdbId = table.Column<int>(type: "INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                AlternateNames = table.Column<string>(type: "TEXT", nullable: true),
                Banner = table.Column<string>(type: "TEXT", nullable: true),
                CustomFormat = table.Column<string>(type: "TEXT", nullable: true),
                FolderName = table.Column<string>(type: "TEXT", nullable: true),
                LastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                Locked = table.Column<bool>(type: "INTEGER", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: true),
                UseCustomFormat = table.Column<bool>(type: "INTEGER", nullable: false),
                UseDvdOrder = table.Column<bool>(type: "INTEGER", nullable: false),
                UseCustomDestination = table.Column<bool>(type: "INTEGER", nullable: false),
                CustomDestinationDir = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TvShows", x => x.TvdbId);
            });

        migrationBuilder.CreateTable(
            name: "Episodes",
            columns: table => new
            {
                TvdbId = table.Column<string>(type: "TEXT", nullable: false),
                EpisodeNumber = table.Column<int>(type: "INTEGER", nullable: false),
                FileCount = table.Column<int>(type: "INTEGER", nullable: false),
                FirstAir = table.Column<DateTime>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: true),
                SeasonNumber = table.Column<int>(type: "INTEGER", nullable: false),
                ShowId = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Episodes", x => x.TvdbId);
                table.ForeignKey(
                    name: "FK_Episodes_TvShows_ShowId",
                    column: x => x.ShowId,
                    principalTable: "TvShows",
                    principalColumn: "TvdbId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Episodes_ShowId",
            table: "Episodes",
            column: "ShowId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Episodes");

        migrationBuilder.DropTable(
            name: "Setting");

        migrationBuilder.DropTable(
            name: "TvShows");
    }
}

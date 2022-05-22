using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ingatlan_back_end.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategoriak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ingatlanok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Leiras = table.Column<string>(nullable: true),
                    HirdetesDatuma = table.Column<DateTime>(nullable: false),
                    Tehermentes = table.Column<bool>(nullable: false),
                    Ar = table.Column<uint>(nullable: false),
                    KepUrl = table.Column<string>(nullable: true),
                    KategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingatlanok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ingatlanok_kategoriak_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "kategoriak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "kategoriak",
                columns: new[] { "Id", "Nev" },
                values: new object[,]
                {
                    { 1, "Ház" },
                    { 2, "Lakás" },
                    { 3, "Építési telek" },
                    { 4, "Garázs" },
                    { 5, "Mezőgazdasági terület" },
                    { 6, "Ipari ingatlan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingatlanok_KategoriaId",
                table: "ingatlanok",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_kategoriak_Nev",
                table: "kategoriak",
                column: "Nev",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingatlanok");

            migrationBuilder.DropTable(
                name: "kategoriak");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bica_Ionut_Bogdan.Migrations
{
    public partial class InnitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieAlergii",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    catAlergii = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieAlergii", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocatieDepozite",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    locatieDepozit = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocatieDepozite", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    produsNume = table.Column<string>(maxLength: 30, nullable: false),
                    produsDescriere = table.Column<string>(maxLength: 30, nullable: false),
                    produsSeal = table.Column<string>(maxLength: 30, nullable: false),
                    produsExp = table.Column<DateTime>(nullable: false),
                    CategorieAlergiiID = table.Column<int>(nullable: false),
                    LocatieDepoziteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Produs_CategorieAlergii_CategorieAlergiiID",
                        column: x => x.CategorieAlergiiID,
                        principalTable: "CategorieAlergii",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produs_LocatieDepozite_LocatieDepoziteID",
                        column: x => x.LocatieDepoziteID,
                        principalTable: "LocatieDepozite",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_CategorieAlergiiID",
                table: "Produs",
                column: "CategorieAlergiiID");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_LocatieDepoziteID",
                table: "Produs",
                column: "LocatieDepoziteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropTable(
                name: "CategorieAlergii");

            migrationBuilder.DropTable(
                name: "LocatieDepozite");
        }
    }
}

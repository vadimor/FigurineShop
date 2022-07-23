using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalog.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "catalog_item_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_material_hilo",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "catalog_source_hilo",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "CatalogMaterial",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogSource",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Weight = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    CatalogMaterialId = table.Column<int>(type: "integer", nullable: false),
                    CatalogSourceId = table.Column<int>(type: "integer", nullable: false),
                    PictureFileName = table.Column<string>(type: "text", nullable: false),
                    AvailableStock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogMaterial_CatalogMaterialId",
                        column: x => x.CatalogMaterialId,
                        principalTable: "CatalogMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogSource_CatalogSourceId",
                        column: x => x.CatalogSourceId,
                        principalTable: "CatalogSource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogMaterialId",
                table: "CatalogItem",
                column: "CatalogMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogSourceId",
                table: "CatalogItem",
                column: "CatalogSourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItem");

            migrationBuilder.DropTable(
                name: "CatalogMaterial");

            migrationBuilder.DropTable(
                name: "CatalogSource");

            migrationBuilder.DropSequence(
                name: "catalog_item_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_material_hilo");

            migrationBuilder.DropSequence(
                name: "catalog_source_hilo");
        }
    }
}

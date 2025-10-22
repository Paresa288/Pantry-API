using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedIntermediateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "ItemStorageLocation");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Stock",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => new { x.CategoriesId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_CategoryItem_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemStorageLocation",
                columns: table => new
                {
                    ItemsId = table.Column<int>(type: "int", nullable: false),
                    LocationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStorageLocation", x => new { x.ItemsId, x.LocationsId });
                    table.ForeignKey(
                        name: "FK_ItemStorageLocation_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemStorageLocation_StorageLocations_LocationsId",
                        column: x => x.LocationsId,
                        principalTable: "StorageLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemsId",
                table: "CategoryItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemStorageLocation_LocationsId",
                table: "ItemStorageLocation",
                column: "LocationsId");
        }
    }
}

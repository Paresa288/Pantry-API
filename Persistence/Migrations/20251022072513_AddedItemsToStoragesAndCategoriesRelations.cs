using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedItemsToStoragesAndCategoriesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_StorageLocations_LocationId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_LocationId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_UserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Items");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "ItemStorageLocation");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserId",
                table: "Items",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryId",
                table: "Items",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_StorageLocations_LocationId",
                table: "Items",
                column: "LocationId",
                principalTable: "StorageLocations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Users_UserId",
                table: "Items",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

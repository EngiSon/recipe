using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecipeAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIngredientAndNamesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_FavoritedUsersId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_UsersFavoritedId",
                table: "UserUser");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.RenameColumn(
                name: "UsersFavoritedId",
                table: "UserUser",
                newName: "OutgoingFavoritesId");

            migrationBuilder.RenameColumn(
                name: "FavoritedUsersId",
                table: "UserUser",
                newName: "IncomingFavoritesId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser_UsersFavoritedId",
                table: "UserUser",
                newName: "IX_UserUser_OutgoingFavoritesId");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_IncomingFavoritesId",
                table: "UserUser",
                column: "IncomingFavoritesId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_OutgoingFavoritesId",
                table: "UserUser",
                column: "OutgoingFavoritesId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_IncomingFavoritesId",
                table: "UserUser");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUser_Users_OutgoingFavoritesId",
                table: "UserUser");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "OutgoingFavoritesId",
                table: "UserUser",
                newName: "UsersFavoritedId");

            migrationBuilder.RenameColumn(
                name: "IncomingFavoritesId",
                table: "UserUser",
                newName: "FavoritedUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_UserUser_OutgoingFavoritesId",
                table: "UserUser",
                newName: "IX_UserUser_UsersFavoritedId");

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeId",
                table: "Ingredient",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_FavoritedUsersId",
                table: "UserUser",
                column: "FavoritedUsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUser_Users_UsersFavoritedId",
                table: "UserUser",
                column: "UsersFavoritedId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

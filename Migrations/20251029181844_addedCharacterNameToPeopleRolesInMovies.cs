using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class addedCharacterNameToPeopleRolesInMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "People");

            migrationBuilder.AddColumn<string>(
                name: "CharacterName",
                table: "PeopleRolesInMovies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CharacterName",
                table: "PeopleRolesInMovies");

            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "People",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}

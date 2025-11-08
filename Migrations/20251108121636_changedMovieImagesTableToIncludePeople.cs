using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class changedMovieImagesTableToIncludePeople : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMoviePoster",
                table: "MovieImages",
                newName: "IsPoster");

            migrationBuilder.AddColumn<int>(
                name: "PeopleId",
                table: "MovieImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImages_People_MovieId",
                table: "MovieImages",
                column: "MovieId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImages_People_MovieId",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "PeopleId",
                table: "MovieImages");

            migrationBuilder.RenameColumn(
                name: "IsPoster",
                table: "MovieImages",
                newName: "IsMoviePoster");
        }
    }
}

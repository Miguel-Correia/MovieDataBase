using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class fixedFRMovieImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImages_People_MovieId",
                table: "MovieImages");

            migrationBuilder.CreateIndex(
                name: "IX_MovieImages_PeopleId",
                table: "MovieImages",
                column: "PeopleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImages_People_PeopleId",
                table: "MovieImages",
                column: "PeopleId",
                principalTable: "People",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImages_People_PeopleId",
                table: "MovieImages");

            migrationBuilder.DropIndex(
                name: "IX_MovieImages_PeopleId",
                table: "MovieImages");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImages_People_MovieId",
                table: "MovieImages",
                column: "MovieId",
                principalTable: "People",
                principalColumn: "Id");
        }
    }
}

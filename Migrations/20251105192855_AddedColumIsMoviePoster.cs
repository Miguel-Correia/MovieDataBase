using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumIsMoviePoster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMoviePoster",
                table: "MovieImages",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMoviePoster",
                table: "MovieImages");
        }
    }
}

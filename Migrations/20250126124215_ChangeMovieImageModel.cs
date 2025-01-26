using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMovieImageModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "MovieImages",
                newName: "FileExtension");

            migrationBuilder.AddColumn<byte[]>(
                name: "Bytes",
                table: "MovieImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "MovieImages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "MovieImages");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "MovieImages",
                newName: "image");
        }
    }
}

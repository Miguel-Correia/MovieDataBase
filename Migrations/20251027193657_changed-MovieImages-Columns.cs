using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class changedMovieImagesColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "MovieImages");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "MovieImages",
                newName: "imageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "MovieImages",
                newName: "FileExtension");

            migrationBuilder.AddColumn<byte[]>(
                name: "Bytes",
                table: "MovieImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "MovieImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "MovieImages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}

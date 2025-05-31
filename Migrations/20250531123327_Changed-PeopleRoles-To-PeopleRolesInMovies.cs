using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPeopleRolesToPeopleRolesInMovies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleRole");

            migrationBuilder.CreateTable(
                name: "PeopleRolesInMovies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleRolesInMovies", x => new { x.MovieId, x.PeopleId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PeopleRolesInMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleRolesInMovies_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleRolesInMovies_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleRolesInMovies_PeopleId",
                table: "PeopleRolesInMovies",
                column: "PeopleId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleRolesInMovies_RoleId",
                table: "PeopleRolesInMovies",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleRolesInMovies");

            migrationBuilder.CreateTable(
                name: "PeopleRole",
                columns: table => new
                {
                    PeopleId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleRole", x => new { x.PeopleId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_PeopleRole_People_PeopleId",
                        column: x => x.PeopleId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleRole_RoleId",
                table: "PeopleRole",
                column: "RoleId");
        }
    }
}

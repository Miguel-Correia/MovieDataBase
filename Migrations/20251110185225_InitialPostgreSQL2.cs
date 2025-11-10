using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDataBase.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgreSQL2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_death",
                table: "people",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "date_of_birth",
                table: "people",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1970, 7, 30), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1959, 1, 28), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1964, 7, 11), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1951, 5, 14), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1945, 3, 3), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1969, 9, 14), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1974, 1, 30), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1979, 4, 4), new DateOnly(2008, 1, 22) });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1937, 6, 1), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1958, 10, 16), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1983, 12, 20), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1988, 6, 7), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1974, 11, 11), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1977, 9, 15), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1987, 2, 21), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1956, 7, 9), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1975, 8, 7), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1969, 11, 4), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1982, 11, 12), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1967, 1, 17), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1976, 6, 6), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1965, 12, 22), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1947, 9, 21), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1982, 4, 15), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1982, 9, 11), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1945, 3, 22), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1943, 3, 23), new DateOnly(2020, 9, 17) });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1957, 3, 28), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1989, 1, 1), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1971, 12, 9), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1949, 8, 2), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1952, 6, 8), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1967, 12, 6), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1968, 5, 15), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1960, 1, 1), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1949, 2, 14), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1952, 10, 15), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1950, 4, 14), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1968, 3, 12), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateOnly(1975, 5, 20), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_death",
                table: "people",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "people",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1970, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1959, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1964, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1951, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1945, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1969, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1974, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1979, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2008, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1937, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1958, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1983, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1988, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1974, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1977, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1987, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1975, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1969, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1982, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1967, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1976, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1965, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 23,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 24,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1982, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 25,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1982, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 26,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1945, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 27,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1943, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 28,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1957, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 29,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1989, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 30,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1971, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 31,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1949, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 32,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1952, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 33,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1967, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 34,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1968, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 35,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1960, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 36,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1949, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 37,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1952, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 38,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1950, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 39,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1968, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "people",
                keyColumn: "id",
                keyValue: 40,
                columns: new[] { "date_of_birth", "date_of_death" },
                values: new object[] { new DateTime(1975, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null });
        }
    }
}

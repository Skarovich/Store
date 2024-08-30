using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class SeedImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("239f8b57-dedd-49f7-b83f-a365bb84710d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6ba5295a-6cef-4389-bad9-4f328f5bc10c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e687128e-a980-42e3-bda7-77d595954948"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b4617da-1fc7-4fbe-a142-9d6d81aa9561"), "Кухня" },
                    { new Guid("422ce6bf-8998-4a1d-bbba-eb559227a686"), "Ванна" },
                    { new Guid("675a4286-6e41-4771-8fde-3ad9e289164a"), "Дом" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Extenstion" },
                values: new object[] { new Guid("d6c1daf5-ae57-41df-8682-085dfcfd4dab"), "jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2b4617da-1fc7-4fbe-a142-9d6d81aa9561"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("422ce6bf-8998-4a1d-bbba-eb559227a686"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("675a4286-6e41-4771-8fde-3ad9e289164a"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("d6c1daf5-ae57-41df-8682-085dfcfd4dab"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("239f8b57-dedd-49f7-b83f-a365bb84710d"), "Кухня" },
                    { new Guid("6ba5295a-6cef-4389-bad9-4f328f5bc10c"), "Дом" },
                    { new Guid("e687128e-a980-42e3-bda7-77d595954948"), "Ванна" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

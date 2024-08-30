using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class EntityItemChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1d2f41b9-3248-4fc9-a60a-91a16484fe89"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ed6359da-8171-4c39-9645-ff7e5babb3ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("edbd309b-ed82-4c5c-8ef1-25e2f2b4cb1c"));

            migrationBuilder.AddColumn<string>(
                name: "CategoryIds",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14a6ed20-13cf-44a2-b9c4-f5855c413958"), "Ванна" },
                    { new Guid("96f31628-c271-4c36-b0dd-bac5f4c6c578"), "Кухня" },
                    { new Guid("f6d0354b-cc58-4d78-a381-dbe16c1d300e"), "Дом" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("14a6ed20-13cf-44a2-b9c4-f5855c413958"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("96f31628-c271-4c36-b0dd-bac5f4c6c578"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f6d0354b-cc58-4d78-a381-dbe16c1d300e"));

            migrationBuilder.DropColumn(
                name: "CategoryIds",
                table: "Items");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d2f41b9-3248-4fc9-a60a-91a16484fe89"), "Ванна" },
                    { new Guid("ed6359da-8171-4c39-9645-ff7e5babb3ff"), "Дом" },
                    { new Guid("edbd309b-ed82-4c5c-8ef1-25e2f2b4cb1c"), "Кухня" }
                });
        }
    }
}

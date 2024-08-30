﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store.Migrations
{
    /// <inheritdoc />
    public partial class EntityConfigurationChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(20,2)",
                precision: 20,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(5,2)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(20,2)",
                oldPrecision: 20);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2b4617da-1fc7-4fbe-a142-9d6d81aa9561"), "Кухня" },
                    { new Guid("422ce6bf-8998-4a1d-bbba-eb559227a686"), "Ванна" },
                    { new Guid("675a4286-6e41-4771-8fde-3ad9e289164a"), "Дом" }
                });
        }
    }
}

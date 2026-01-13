using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplonHubApi.Migrations
{
    /// <inheritdoc />
    public partial class imagurluser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("cde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("da5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("eba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2960));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2956));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2963));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("022eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("33a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("44f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("9de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("aa5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3053));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("066eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3181));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3178));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("88f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3187));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2826));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("7de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3278));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("8a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3281));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { "#c7f2e9", new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3231) });

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { "#f2cec7", new DateTime(2025, 11, 22, 12, 38, 27, 754, DateTimeKind.Utc).AddTicks(3228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("cde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6614));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("da5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("eba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6486));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6480));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6488));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("022eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6659));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("33a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("44f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6664));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("9de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6564));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("aa5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("066eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6697));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("88f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6700));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6397));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6401));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6403));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("7de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("8a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6767));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6524));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6529));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { "#aa69b4", new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                columns: new[] { "Color", "CreatedAt" },
                values: new object[] { "#ff69b4", new DateTime(2025, 11, 2, 17, 46, 37, 460, DateTimeKind.Utc).AddTicks(6728) });
        }
    }
}

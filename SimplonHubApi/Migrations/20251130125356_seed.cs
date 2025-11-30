using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimplonHubApi.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("cde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("da5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("eba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("022eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3169));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("33a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3171));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("44f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3174));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("9de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("aa5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("066eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("88f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2789));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2793));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2777));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("7de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3285));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("8a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2982));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3725"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.InsertData(
                table: "TypeDocuments",
                columns: new[] { "Id", "ArchivedAt", "Color", "CreatedAt", "Icon", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"), null, "#ff69b4", new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3323), "", "PI", null },
                    { new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"), null, "#fa69b4", new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3329), "", "Diplome", null },
                    { new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"), null, "#fa69b4", new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3327), "", "CG", null }
                });

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 53, 55, 327, DateTimeKind.Utc).AddTicks(3247));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeDocuments",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"));

            migrationBuilder.DeleteData(
                table: "TypeDocuments",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"));

            migrationBuilder.DeleteData(
                table: "TypeDocuments",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("cde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8804));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("da5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8808));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("eba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8810));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8670));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8677));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("022eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("33a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("44f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("9de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8765));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("aa5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8768));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8772));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("066eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8886));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8892));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("88f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8576));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8582));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8563));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("7de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8959));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("8a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8963));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3725"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 30, 12, 44, 27, 678, DateTimeKind.Utc).AddTicks(8924));
        }
    }
}

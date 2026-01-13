using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplonHubApi.Migrations
{
    /// <inheritdoc />
    public partial class typedocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Documents",
                newName: "Extension");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeId",
                table: "Documents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TypeDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDocuments", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TypeId",
                table: "Documents",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_TypeDocuments_TypeId",
                table: "Documents",
                column: "TypeId",
                principalTable: "TypeDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_TypeDocuments_TypeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "TypeDocuments");

            migrationBuilder.DropIndex(
                name: "IX_Documents_TypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "Extension",
                table: "Documents",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("cde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("da5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6426));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("eba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("f1f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6432));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("1de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("2a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6298));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("3ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("022eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("11e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6463));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("33a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("44f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6472));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("9de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6381));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("aa5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6384));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("066eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6508));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("55e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6504));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("77a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("88f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6513));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6161));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("7de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6574));

            migrationBuilder.UpdateData(
                table: "StatusBookings",
                keyColumn: "Id",
                keyValue: new Guid("8a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4de5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("5a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6348));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6350));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("6ba0a5ed-c7bb-4394-a163-7ed7560b3725"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("0aaeaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6543));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("99e5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 29, 19, 51, 44, 582, DateTimeKind.Utc).AddTicks(6538));
        }
    }
}

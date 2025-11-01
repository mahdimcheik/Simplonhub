using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class addstatusbookingwithrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Bookings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "StatusBookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Color = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Icon = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ArchivedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusBookings", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8348));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8232));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8239));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8236));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8390));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8393));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8387));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8316));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8312));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8434));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8429));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8431));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8425));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8125));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8127));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8130));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8279));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8282));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8467));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 11, 1, 19, 18, 31, 688, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_StatusId",
                table: "Bookings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_StatusBookings_StatusId",
                table: "Bookings",
                column: "StatusId",
                principalTable: "StatusBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_StatusBookings_StatusId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "StatusBookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_StatusId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4756));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4639));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4804));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4799));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4795));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4880));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4872));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4545));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4548));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4684));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4686));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 27, 20, 40, 5, 212, DateTimeKind.Utc).AddTicks(5053));
        }
    }
}

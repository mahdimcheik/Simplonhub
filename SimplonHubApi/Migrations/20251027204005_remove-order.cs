using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainBoilerPlate.Migrations
{
    /// <inheritdoc />
    public partial class removeorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Orders_OrderId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_OrderId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "OrderId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Bookings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "CategoryCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7308));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7305));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7497));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7492));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7495));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7406));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7409));

            migrationBuilder.UpdateData(
                table: "LevelCursuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7402));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("41f1f997-c392-4aac-bef0-fc8acaf109ec"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7533));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7528));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7530));

            migrationBuilder.UpdateData(
                table: "ProgrammingLanguages",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7159));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b4a01"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7162));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7142));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7360));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("87a0a5ed-c7bb-4394-a163-7ed7560b3703"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7363));

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7357));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("4a5eaf2f-0496-4035-a4b7-9210da39501c"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7567));

            migrationBuilder.UpdateData(
                table: "TypeSlots",
                keyColumn: "Id",
                keyValue: new Guid("bde5556b-562d-431f-9ff9-d31a5f5cb8c5"),
                column: "CreatedAt",
                value: new DateTime(2025, 10, 26, 18, 58, 54, 579, DateTimeKind.Utc).AddTicks(7564));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OrderId",
                table: "Bookings",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Orders_OrderId",
                table: "Bookings",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class TaskBoardIdNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae10897d-60d3-4b89-8cdd-52f3d751c8d8");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Board identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "Board identifier");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f", 0, "9ecdc0e7-355e-48c4-9634-54197affe7db", null, false, false, null, null, "TESTUSER@TEST.BG", "AQAAAAEAACcQAAAAENFmA68nSJUkZKTLZmqgOSbh7wMDxXYvaXJwRwQO88yemqhyLsAA20woIg2F+VtUbw==", null, false, "dc72898d-a9bd-4e87-8162-10f60e5c9cc1", false, "testUser@test.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 7, 31, 15, 49, 42, 329, DateTimeKind.Local).AddTicks(6324), "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 16, 15, 49, 42, 329, DateTimeKind.Local).AddTicks(6380), "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 49, 42, 329, DateTimeKind.Local).AddTicks(6388), "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 16, 15, 49, 42, 329, DateTimeKind.Local).AddTicks(6394), "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4b25c7ad-c42b-4f92-bac5-c55c2b67ae1f");

            migrationBuilder.AlterColumn<int>(
                name: "BoardId",
                table: "Tasks",
                type: "int",
                nullable: true,
                comment: "Board identifier",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Board identifier");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", 0, "b50468f0-f646-4669-90e4-9832d5d136cc", null, false, false, null, null, "TESTUSER@TEST.BG", "AQAAAAEAACcQAAAAEGO0bRdrdICdfZk62CzIfxVc5UFavNUj9vl+wjlZOOgrJiYjnzipcbR28QO/UPkgmA==", null, false, "c5ad66a3-79f5-4a35-afc9-6845c54cd476", false, "testUser@test.bg" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 7, 30, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(672), "ae10897d-60d3-4b89-8cdd-52f3d751c8d8" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 9, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(714), "ae10897d-60d3-4b89-8cdd-52f3d751c8d8" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2024, 1, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(720), "ae10897d-60d3-4b89-8cdd-52f3d751c8d8" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedOn", "OwnerId" },
                values: new object[] { new DateTime(2023, 2, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(727), "ae10897d-60d3-4b89-8cdd-52f3d751c8d8" });
        }
    }
}

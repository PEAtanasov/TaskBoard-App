using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class myIntialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Board identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Board name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Task title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date and time task has been created"),
                    BoardId = table.Column<int>(type: "int", nullable: true, comment: "Board identifier"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Task owner identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", 0, "b50468f0-f646-4669-90e4-9832d5d136cc", null, false, false, null, null, "TESTUSER@TEST.BG", "AQAAAAEAACcQAAAAEGO0bRdrdICdfZk62CzIfxVc5UFavNUj9vl+wjlZOOgrJiYjnzipcbR28QO/UPkgmA==", null, false, "c5ad66a3-79f5-4a35-afc9-6845c54cd476", false, "testUser@test.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 30, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(672), "Implement better styling for all public pages", "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(714), "Create android client app for the TaskBoard RESTful API", "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(720), "Create Windows Form desktop client app for the TaskBoard RESTful API", "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", "Desctop Client App" },
                    { 4, 3, new DateTime(2023, 2, 15, 15, 17, 14, 797, DateTimeKind.Local).AddTicks(727), "Implement [Create Tasks] page for adding new tasks", "ae10897d-60d3-4b89-8cdd-52f3d751c8d8", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae10897d-60d3-4b89-8cdd-52f3d751c8d8");
        }
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class SomeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GitUrl = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestFiles_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProject",
                columns: table => new
                {
                    ProjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProject", x => new { x.ProjectsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UsersProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersProject_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documentation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    TestFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentation_TestFiles_TestFileId",
                        column: x => x.TestFileId,
                        principalTable: "TestFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CreatedDate", "Description", "GitUrl", "Title" },
                values: new object[,]
                {
                    { new Guid("6bcc80d0-f306-4c8c-bf48-2265e19b811b"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(5530), "Dette er en beskrivelse", "Repo5", "Project 5" },
                    { new Guid("72fdc801-cbe7-48c6-bdf8-864ed745848d"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(5530), "Dette er en beskrivelse", "Repo3", "Project 3" },
                    { new Guid("9fa2ded0-668a-45d7-83a3-0c81c72d83f0"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(5530), "Dette er en beskrivelse", "Repo4", "Project 4" },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(5520), "Dette er en beskrivelse", "Repo1", "Project 1" },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(5530), "Dette er en beskrivelse", "Repo2", "Project 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"), new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(4380), "Jens@gmail.com", "Jens", "1234" },
                    { new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638"), new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(4380), "Bo@gmail.com", "Bo", "1234" }
                });

            migrationBuilder.InsertData(
                table: "TestFiles",
                columns: new[] { "Id", "Content", "CreatedDate", "Name", "Path", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("0482336c-9de0-4472-8dbc-c2c53722f394"), "Jeg er også et script", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2030), "TestFile 6", "somePath6", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") },
                    { new Guid("21444a04-eea6-4d61-84b6-2d260463a923"), "Jeg er også et script", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2010), "TestFile 3", "somePath3", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er også et script", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2000), "TestFile 2", "somePath2", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("9fa4c352-9c73-49f4-95e3-bda8b7b302a7"), "Jeg er også et script", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2020), "TestFile 5", "somePath5", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") },
                    { new Guid("ee61a729-a960-467a-bdc1-1d7184ee7346"), "Jeg er et script content", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2000), "TestFile 1", "somePath", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("f823f652-5f9a-4eee-9658-b0228db23b51"), "Jeg er også et script", new DateTime(2023, 4, 7, 13, 36, 39, 653, DateTimeKind.Utc).AddTicks(2020), "TestFile 4", "somePath4", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") }
                });

            migrationBuilder.InsertData(
                table: "UsersProject",
                columns: new[] { "ProjectsId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("6bcc80d0-f306-4c8c-bf48-2265e19b811b"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("72fdc801-cbe7-48c6-bdf8-864ed745848d"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("9fa2ded0-668a-45d7-83a3-0c81c72d83f0"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") }
                });

            migrationBuilder.InsertData(
                table: "Documentation",
                columns: new[] { "Id", "CreatedDate", "Summary", "TestFileId", "Translation" },
                values: new object[] { new Guid("807ed932-9157-4511-bdaa-e565f4e58c23"), new DateTime(2023, 4, 7, 13, 36, 39, 652, DateTimeKind.Utc).AddTicks(2700), "Jeg er et summary", new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er en translation" });

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_TestFileId",
                table: "Documentation",
                column: "TestFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GitUrl",
                table: "Projects",
                column: "GitUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TestFiles_ProjectId",
                table: "TestFiles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersProject_UsersId",
                table: "UsersProject",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentation");

            migrationBuilder.DropTable(
                name: "UsersProject");

            migrationBuilder.DropTable(
                name: "TestFiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

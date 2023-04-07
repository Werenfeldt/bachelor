using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class NewInitDatabase : Migration
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
                    { new Guid("2546ce38-af6f-470e-be38-8d7933742fc8"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260), "Dette er en beskrivelse", "Repo5", "Project 5" },
                    { new Guid("31199508-4b78-49a5-9915-e3600dcbda45"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260), "Dette er en beskrivelse", "Repo3", "Project 3" },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260), "Dette er en beskrivelse", "Repo1", "Project 1" },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260), "Dette er en beskrivelse", "Repo2", "Project 2" },
                    { new Guid("e3e05986-41bf-4096-a0c2-9ae2ecabb047"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260), "Dette er en beskrivelse", "Repo4", "Project 4" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7990), "Jens@gmail.com", "Jens", "1234" },
                    { new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(8000), "Bo@gmail.com", "Bo", "1234" }
                });

            migrationBuilder.InsertData(
                table: "TestFiles",
                columns: new[] { "Id", "Content", "CreatedDate", "Name", "Path", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("17588608-134b-4c6c-8654-2110ddfc361c"), "Jeg er også et script", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7360), "TestFile 6", "somePath6", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") },
                    { new Guid("21444a04-eea6-4d61-84b6-2d260463a923"), "Jeg er også et script", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7340), "TestFile 3", "somePath3", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("32fe81a1-47de-48da-9628-a9f29a97ff0f"), "Jeg er også et script", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350), "TestFile 4", "somePath4", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er også et script", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330), "TestFile 2", "somePath2", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("ee61a729-a960-467a-bdc1-1d7184ee7346"), "Jeg er et script content", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330), "TestFile 1", "somePath", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("fb1b4f6c-df93-4449-bc08-d7270ce05919"), "Jeg er også et script", new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350), "TestFile 5", "somePath5", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") }
                });

            migrationBuilder.InsertData(
                table: "UsersProject",
                columns: new[] { "ProjectsId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("2546ce38-af6f-470e-be38-8d7933742fc8"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("31199508-4b78-49a5-9915-e3600dcbda45"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") },
                    { new Guid("e3e05986-41bf-4096-a0c2-9ae2ecabb047"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") }
                });

            migrationBuilder.InsertData(
                table: "Documentation",
                columns: new[] { "Id", "CreatedDate", "Summary", "TestFileId", "Translation" },
                values: new object[] { new Guid("e5954e32-3d94-4280-b2ef-7c4b1b4bbb7f"), new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(4260), "Jeg er et summary", new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er en translation" });

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

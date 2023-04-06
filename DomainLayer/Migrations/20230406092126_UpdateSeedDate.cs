using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DomainLayer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedDate : Migration
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
                    GitRepoName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GitRepoOwner = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                columns: new[] { "Id", "CreatedDate", "Description", "GitRepoName", "GitRepoOwner", "Title" },
                values: new object[,]
                {
                    { new Guid("2d11a37e-9f9a-485d-9921-346c19b59e7b"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(570), "Dette er en beskrivelse", "Repo4", "OwnerBo", "Project 4" },
                    { new Guid("8bf19e4d-3abf-4504-8fbb-65d50a2cfd9e"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(570), "Dette er en beskrivelse", "Repo5", "OwnerBo", "Project 5" },
                    { new Guid("ac2493fc-1a2f-4462-9707-86968b937254"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(570), "Dette er en beskrivelse", "Repo3", "OwnerBo", "Project 3" },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(570), "Dette er en beskrivelse", "Repo1", "OwnerJens", "Project 1" },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(570), "Dette er en beskrivelse", "Repo2", "OwnerBo", "Project 2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(3330), "Jens@gmail.com", "Jens", "1234" },
                    { new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638"), new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(3330), "Bo@gmail.com", "Bo", "1234" }
                });

            migrationBuilder.InsertData(
                table: "TestFiles",
                columns: new[] { "Id", "Content", "CreatedDate", "Name", "Path", "ProjectId" },
                values: new object[,]
                {
                    { new Guid("19528834-83ea-44f2-8beb-594300d0e9e1"), "Jeg er også et script", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2680), "TestFile 4", "somePath4", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("21444a04-eea6-4d61-84b6-2d260463a923"), "Jeg er også et script", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2660), "TestFile 3", "somePath3", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("5d4e7b0d-3ff2-4ffd-abb6-1e0583731a23"), "Jeg er også et script", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2680), "TestFile 5", "somePath5", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") },
                    { new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er også et script", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2660), "TestFile 2", "somePath2", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") },
                    { new Guid("8301384b-0d85-4f87-bcd5-367f5320a2d3"), "Jeg er også et script", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2690), "TestFile 6", "somePath6", new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29") },
                    { new Guid("ee61a729-a960-467a-bdc1-1d7184ee7346"), "Jeg er et script content", new DateTime(2023, 4, 6, 9, 21, 26, 303, DateTimeKind.Utc).AddTicks(2660), "TestFile 1", "somePath", new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6") }
                });

            migrationBuilder.InsertData(
                table: "UsersProject",
                columns: new[] { "ProjectsId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("2d11a37e-9f9a-485d-9921-346c19b59e7b"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("8bf19e4d-3abf-4504-8fbb-65d50a2cfd9e"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("ac2493fc-1a2f-4462-9707-86968b937254"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("596bd00e-8699-4183-850f-14dc879bf9d8") },
                    { new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"), new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638") }
                });

            migrationBuilder.InsertData(
                table: "Documentation",
                columns: new[] { "Id", "CreatedDate", "Summary", "TestFileId", "Translation" },
                values: new object[] { new Guid("0427d31b-5d96-449b-b420-ddaadceaefb2"), new DateTime(2023, 4, 6, 9, 21, 26, 302, DateTimeKind.Utc).AddTicks(9600), "Jeg er et summary", new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"), "Jeg er en translation" });

            migrationBuilder.CreateIndex(
                name: "IX_Documentation_TestFileId",
                table: "Documentation",
                column: "TestFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GitRepoName_GitRepoOwner",
                table: "Projects",
                columns: new[] { "GitRepoName", "GitRepoOwner" },
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

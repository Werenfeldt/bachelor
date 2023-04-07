﻿// <auto-generated />
using System;
using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DomainLayer.Migrations
{
    [DbContext(typeof(BachelorDbContext))]
    partial class BachelorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DomainLayer.Documentation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TestFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("TestFileId")
                        .IsUnique();

                    b.ToTable("Documentation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e5954e32-3d94-4280-b2ef-7c4b1b4bbb7f"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(4260),
                            Summary = "Jeg er et summary",
                            TestFileId = new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"),
                            Translation = "Jeg er en translation",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(4260)
                        });
                });

            modelBuilder.Entity("DomainLayer.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("GitUrl")
                        .IsUnique();

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260),
                            Description = "Dette er en beskrivelse",
                            GitUrl = "Repo1",
                            Title = "Project 1",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260)
                        },
                        new
                        {
                            Id = new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260),
                            Description = "Dette er en beskrivelse",
                            GitUrl = "Repo2",
                            Title = "Project 2",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260)
                        },
                        new
                        {
                            Id = new Guid("31199508-4b78-49a5-9915-e3600dcbda45"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260),
                            Description = "Dette er en beskrivelse",
                            GitUrl = "Repo3",
                            Title = "Project 3",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260)
                        },
                        new
                        {
                            Id = new Guid("e3e05986-41bf-4096-a0c2-9ae2ecabb047"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260),
                            Description = "Dette er en beskrivelse",
                            GitUrl = "Repo4",
                            Title = "Project 4",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260)
                        },
                        new
                        {
                            Id = new Guid("2546ce38-af6f-470e-be38-8d7933742fc8"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260),
                            Description = "Dette er en beskrivelse",
                            GitUrl = "Repo5",
                            Title = "Project 5",
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(5260)
                        });
                });

            modelBuilder.Entity("DomainLayer.TestFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("TestFiles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ee61a729-a960-467a-bdc1-1d7184ee7346"),
                            Content = "Jeg er et script content",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330),
                            Name = "TestFile 1",
                            Path = "somePath",
                            ProjectId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330)
                        },
                        new
                        {
                            Id = new Guid("6ea2fe17-3be2-4990-aa44-d233698ac483"),
                            Content = "Jeg er også et script",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330),
                            Name = "TestFile 2",
                            Path = "somePath2",
                            ProjectId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7330)
                        },
                        new
                        {
                            Id = new Guid("21444a04-eea6-4d61-84b6-2d260463a923"),
                            Content = "Jeg er også et script",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7340),
                            Name = "TestFile 3",
                            Path = "somePath3",
                            ProjectId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7340)
                        },
                        new
                        {
                            Id = new Guid("32fe81a1-47de-48da-9628-a9f29a97ff0f"),
                            Content = "Jeg er også et script",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350),
                            Name = "TestFile 4",
                            Path = "somePath4",
                            ProjectId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350)
                        },
                        new
                        {
                            Id = new Guid("fb1b4f6c-df93-4449-bc08-d7270ce05919"),
                            Content = "Jeg er også et script",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350),
                            Name = "TestFile 5",
                            Path = "somePath5",
                            ProjectId = new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7350)
                        },
                        new
                        {
                            Id = new Guid("17588608-134b-4c6c-8654-2110ddfc361c"),
                            Content = "Jeg er også et script",
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7360),
                            Name = "TestFile 6",
                            Path = "somePath6",
                            ProjectId = new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                            UpdatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7360)
                        });
                });

            modelBuilder.Entity("DomainLayer.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(7990),
                            Email = "Jens@gmail.com",
                            Name = "Jens",
                            Password = "1234"
                        },
                        new
                        {
                            Id = new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638"),
                            CreatedDate = new DateTime(2023, 4, 7, 20, 40, 5, 844, DateTimeKind.Utc).AddTicks(8000),
                            Email = "Bo@gmail.com",
                            Name = "Bo",
                            Password = "1234"
                        });
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("UsersProject", (string)null);

                    b.HasData(
                        new
                        {
                            ProjectsId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UsersId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8")
                        },
                        new
                        {
                            ProjectsId = new Guid("bfaf6610-6eaf-4bf2-8d08-eadaf01d2fd6"),
                            UsersId = new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638")
                        },
                        new
                        {
                            ProjectsId = new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                            UsersId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8")
                        },
                        new
                        {
                            ProjectsId = new Guid("d91cc4d8-f22a-4aa9-841d-3f8540c01f29"),
                            UsersId = new Guid("5f6bd9e2-569f-40ea-8f27-79f3b87e1638")
                        },
                        new
                        {
                            ProjectsId = new Guid("31199508-4b78-49a5-9915-e3600dcbda45"),
                            UsersId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8")
                        },
                        new
                        {
                            ProjectsId = new Guid("e3e05986-41bf-4096-a0c2-9ae2ecabb047"),
                            UsersId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8")
                        },
                        new
                        {
                            ProjectsId = new Guid("2546ce38-af6f-470e-be38-8d7933742fc8"),
                            UsersId = new Guid("596bd00e-8699-4183-850f-14dc879bf9d8")
                        });
                });

            modelBuilder.Entity("DomainLayer.Documentation", b =>
                {
                    b.HasOne("DomainLayer.TestFile", "TestFile")
                        .WithOne("Documentation")
                        .HasForeignKey("DomainLayer.Documentation", "TestFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TestFile");
                });

            modelBuilder.Entity("DomainLayer.TestFile", b =>
                {
                    b.HasOne("DomainLayer.Project", "Project")
                        .WithMany("TestFiles")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("DomainLayer.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DomainLayer.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DomainLayer.Project", b =>
                {
                    b.Navigation("TestFiles");
                });

            modelBuilder.Entity("DomainLayer.TestFile", b =>
                {
                    b.Navigation("Documentation");
                });
#pragma warning restore 612, 618
        }
    }
}

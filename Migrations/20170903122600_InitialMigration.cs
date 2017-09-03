using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyWeeFee.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_APEncryptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Encryption = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_APEncryptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ExamMode = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Logitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Logitems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Accesspoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    APEncryptionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Encryption = table.Column<int>(type: "INTEGER", maxLength: 20, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SSID = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Accesspoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Accesspoints_T_APEncryptions_APEncryptionId",
                        column: x => x.APEncryptionId,
                        principalTable: "T_APEncryptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "T_Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Students_T_Classes_Id",
                        column: x => x.Id,
                        principalTable: "T_Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Accesspoints_APEncryptionId",
                table: "T_Accesspoints",
                column: "APEncryptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Accesspoints");

            migrationBuilder.DropTable(
                name: "T_Admins");

            migrationBuilder.DropTable(
                name: "T_Logitems");

            migrationBuilder.DropTable(
                name: "T_Students");

            migrationBuilder.DropTable(
                name: "T_Teachers");

            migrationBuilder.DropTable(
                name: "T_APEncryptions");

            migrationBuilder.DropTable(
                name: "T_Classes");
        }
    }
}

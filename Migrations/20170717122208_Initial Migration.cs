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
                name: "T_Accesspoints",
                columns: table => new
                {
                    Location = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Encryption = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    SSID = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Accesspoints", x => x.Location);
                });

            migrationBuilder.CreateTable(
                name: "T_Admins",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Admins", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "T_Classes",
                columns: table => new
                {
                    ClassName = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    ExamMode = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Classes", x => x.ClassName);
                });

            migrationBuilder.CreateTable(
                name: "T_Teachers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Teachers", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "T_Students",
                columns: table => new
                {
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ClassName = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    IsBlocked = table.Column<bool>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surename = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Students", x => x.Email);
                    table.ForeignKey(
                        name: "FK_T_Students_T_Classes_ClassName",
                        column: x => x.ClassName,
                        principalTable: "T_Classes",
                        principalColumn: "ClassName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Students_ClassName",
                table: "T_Students",
                column: "ClassName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Accesspoints");

            migrationBuilder.DropTable(
                name: "T_Admins");

            migrationBuilder.DropTable(
                name: "T_Students");

            migrationBuilder.DropTable(
                name: "T_Teachers");

            migrationBuilder.DropTable(
                name: "T_Classes");
        }
    }
}

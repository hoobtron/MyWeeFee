﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using MyWeeFee.Models;
using System;

namespace MyWeeFee.Migrations
{
    [DbContext(typeof(MyWeeFeeContext))]
    partial class MyWeeFeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("MyWeeFee.Models.Accesspoint", b =>
                {
                    b.Property<string>("Location")
                        .HasMaxLength(20);

                    b.Property<string>("Encryption")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("WPA2")
                        .HasMaxLength(20);

                    b.Property<string>("SSID")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Location");

                    b.ToTable("T_Accesspoints");
                });

            modelBuilder.Entity("MyWeeFee.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Surename")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("T_Admins");
                });

            modelBuilder.Entity("MyWeeFee.Models.Class", b =>
                {
                    b.Property<string>("ClassName")
                        .HasMaxLength(10);

                    b.Property<bool>("ExamMode");

                    b.HasKey("ClassName");

                    b.ToTable("T_Classes");
                });

            modelBuilder.Entity("MyWeeFee.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClassName")
                        .HasMaxLength(10);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<bool>("IsBlocked");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Surename")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("ClassName");

                    b.ToTable("T_Students");
                });

            modelBuilder.Entity("MyWeeFee.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Surename")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("T_Teachers");
                });

            modelBuilder.Entity("MyWeeFee.Models.Student", b =>
                {
                    b.HasOne("MyWeeFee.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassName");
                });
#pragma warning restore 612, 618
        }
    }
}

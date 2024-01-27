﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentGradeMVC.Data;

#nullable disable

namespace StudentGradeMVC.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20230706012042_CheckingUpdates")]
    partial class CheckingUpdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentGradeMVC.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("varchar (250)");

                    b.Property<int?>("MaxStudent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar (50)");

                    b.HasKey("Id");

                    b.ToTable("COURSE");
                });

            modelBuilder.Entity("StudentGradeMVC.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("varchar (250)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar (50)");

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal (18,0)");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentID");

                    b.ToTable("GRADE");
                });

            modelBuilder.Entity("StudentGradeMVC.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Addressln1")
                        .IsRequired()
                        .HasColumnType("varchar (250)");

                    b.Property<string>("Addressln2")
                        .IsRequired()
                        .HasColumnType("varchar (250)");

                    b.Property<int?>("CourseID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar (250)");

                    b.Property<string>("IGTag")
                        .HasColumnType("varchar (50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar (50)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar (11)");

                    b.Property<string>("StudentImage")
                        .HasColumnType("varchar (MAX)");

                    b.Property<string>("TikTokTag")
                        .HasColumnType("varchar (50)");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.ToTable("STUDENT");
                });

            modelBuilder.Entity("StudentGradeMVC.Models.Grade", b =>
                {
                    b.HasOne("StudentGradeMVC.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentID");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudentGradeMVC.Models.Student", b =>
                {
                    b.HasOne("StudentGradeMVC.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID");

                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}
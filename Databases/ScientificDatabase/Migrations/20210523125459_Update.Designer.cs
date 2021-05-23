﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScientificDatabase.Models;

namespace ScientificDatabase.Migrations
{
    [DbContext(typeof(ScientificContext))]
    [Migration("20210523125459_Update")]
    partial class Update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PropertyTypeObject", b =>
                {
                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.Property<int>("TypeObjectsId")
                        .HasColumnType("int");

                    b.HasKey("PropertiesId", "TypeObjectsId");

                    b.HasIndex("TypeObjectsId");

                    b.ToTable("PropertyTypeObject");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Hierarchy.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Hierarchy.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AltName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.DataObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeObjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeObjectId");

                    b.ToTable("DataObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.TypeObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("TypeObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.ValuePropertyObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DataObjectId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DataObjectId");

                    b.HasIndex("PropertyId");

                    b.ToTable("ValuePropertyObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PropertyTypeObject", b =>
                {
                    b.HasOne("ScientificDatabase.Models.TypeObject.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScientificDatabase.Models.TypeObject.TypeObject", null)
                        .WithMany()
                        .HasForeignKey("TypeObjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ScientificDatabase.Models.Hierarchy.Section", b =>
                {
                    b.HasOne("ScientificDatabase.Models.Hierarchy.Area", "Area")
                        .WithMany("Section")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.DataObject", b =>
                {
                    b.HasOne("ScientificDatabase.Models.TypeObject.TypeObject", "TypeObject")
                        .WithMany("DataObjects")
                        .HasForeignKey("TypeObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeObject");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.TypeObject", b =>
                {
                    b.HasOne("ScientificDatabase.Models.Hierarchy.Section", "Section")
                        .WithMany("TypeObjects")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.ValuePropertyObject", b =>
                {
                    b.HasOne("ScientificDatabase.Models.TypeObject.DataObject", "DataObject")
                        .WithMany("ValuePropertyObjects")
                        .HasForeignKey("DataObjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScientificDatabase.Models.TypeObject.Property", "Property")
                        .WithMany("ValuePropertyObjects")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DataObject");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("ScientificDatabase.Models.User", b =>
                {
                    b.HasOne("ScientificDatabase.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Hierarchy.Area", b =>
                {
                    b.Navigation("Section");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Hierarchy.Section", b =>
                {
                    b.Navigation("TypeObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.DataObject", b =>
                {
                    b.Navigation("ValuePropertyObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.Property", b =>
                {
                    b.Navigation("ValuePropertyObjects");
                });

            modelBuilder.Entity("ScientificDatabase.Models.TypeObject.TypeObject", b =>
                {
                    b.Navigation("DataObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
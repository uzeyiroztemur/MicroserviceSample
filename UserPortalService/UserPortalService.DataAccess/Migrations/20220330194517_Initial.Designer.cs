﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserPortalService.DataAccess.Concrete.EntityFramework.Context;

#nullable disable

namespace UserPortalService.DataAccess.Migrations
{
    [DbContext(typeof(UserPortalDbContext))]
    [Migration("20220330194517_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserPortalService.Entities.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("UserPortalService.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("UserPortalService.Entities.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("DeletedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });
#pragma warning restore 612, 618
        }
    }
}

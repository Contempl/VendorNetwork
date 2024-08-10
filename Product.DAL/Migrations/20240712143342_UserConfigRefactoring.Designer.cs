﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.DAL;

#nullable disable

namespace Product.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240712143342_UserConfigRefactoring")]
    partial class UserConfigRefactoring
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Product.Domain.Entity.Administrator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Username");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.ToTable("Administrators", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.Business", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address");

                    b.Property<string>("BusinessName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<string>("BusinessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.HasKey("Id");

                    b.ToTable("Businesses", (string)null);

                    b.HasDiscriminator<string>("BusinessType").HasValue("Business");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Product.Domain.Entity.Invite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedAt");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpiresAt");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Invites", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.OperatorIndustry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Address");

                    b.Property<double>("Latitude")
                        .HasPrecision(10, 8)
                        .HasColumnType("float(10)")
                        .HasColumnName("Latitude");

                    b.Property<double>("Longitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("float(11)")
                        .HasColumnName("Longitude");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Name");

                    b.Property<int>("OperatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperatorId");

                    b.ToTable("Industries", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<int?>("InviteId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Password");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.HasIndex("InviteId")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorFacility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitude")
                        .HasPrecision(10, 8)
                        .HasColumnType("float(10)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Longitude")
                        .HasPrecision(11, 8)
                        .HasColumnType("float(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("RadiusOfWork")
                        .HasColumnType("float");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendorId");

                    b.ToTable("VendorsFacilities", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorFacilityService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("VendorFacilityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VendorFacilityId");

                    b.ToTable("VendorsFacilityServices", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.Operator", b =>
                {
                    b.HasBaseType("Product.Domain.Entity.Business");

                    b.Property<string>("LogoUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LogoUrl");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Occupation");

                    b.HasDiscriminator().HasValue("Operator");
                });

            modelBuilder.Entity("Product.Domain.Entity.Vendor", b =>
                {
                    b.HasBaseType("Product.Domain.Entity.Business");

                    b.HasDiscriminator().HasValue("Vendor");
                });

            modelBuilder.Entity("Product.Domain.Entity.OperatorUser", b =>
                {
                    b.HasBaseType("Product.Domain.Entity.User");

                    b.Property<int?>("OperatorId")
                        .HasColumnType("int");

                    b.HasIndex("OperatorId");

                    b.ToTable("OperatorUsers", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorUser", b =>
                {
                    b.HasBaseType("Product.Domain.Entity.User");

                    b.Property<int?>("VendorId")
                        .HasColumnType("int");

                    b.HasIndex("VendorId");

                    b.ToTable("VendorUsers", (string)null);
                });

            modelBuilder.Entity("Product.Domain.Entity.Invite", b =>
                {
                    b.HasOne("Product.Domain.Entity.Administrator", "Admin")
                        .WithMany("Invites")
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("Product.Domain.Entity.OperatorIndustry", b =>
                {
                    b.HasOne("Product.Domain.Entity.Operator", "Operator")
                        .WithMany("Industries")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Product.Domain.Entity.User", b =>
                {
                    b.HasOne("Product.Domain.Entity.Invite", "Invite")
                        .WithOne("User")
                        .HasForeignKey("Product.Domain.Entity.User", "InviteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Invite");
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorFacility", b =>
                {
                    b.HasOne("Product.Domain.Entity.Vendor", "Vendor")
                        .WithMany("VendorFacilities")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorFacilityService", b =>
                {
                    b.HasOne("Product.Domain.Entity.VendorFacility", "VendorFacility")
                        .WithMany("Services")
                        .HasForeignKey("VendorFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VendorFacility");
                });

            modelBuilder.Entity("Product.Domain.Entity.OperatorUser", b =>
                {
                    b.HasOne("Product.Domain.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("Product.Domain.Entity.OperatorUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product.Domain.Entity.Operator", "Operator")
                        .WithMany("OperatorUsers")
                        .HasForeignKey("OperatorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Operator");
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorUser", b =>
                {
                    b.HasOne("Product.Domain.Entity.User", null)
                        .WithOne()
                        .HasForeignKey("Product.Domain.Entity.VendorUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Product.Domain.Entity.Vendor", "Vendor")
                        .WithMany("VendorUsers")
                        .HasForeignKey("VendorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Vendor");
                });

            modelBuilder.Entity("Product.Domain.Entity.Administrator", b =>
                {
                    b.Navigation("Invites");
                });

            modelBuilder.Entity("Product.Domain.Entity.Invite", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Product.Domain.Entity.VendorFacility", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Product.Domain.Entity.Operator", b =>
                {
                    b.Navigation("Industries");

                    b.Navigation("OperatorUsers");
                });

            modelBuilder.Entity("Product.Domain.Entity.Vendor", b =>
                {
                    b.Navigation("VendorFacilities");

                    b.Navigation("VendorUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

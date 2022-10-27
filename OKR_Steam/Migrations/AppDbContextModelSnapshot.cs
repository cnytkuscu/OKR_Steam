﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OKR_Steam.DataAccess.DA;

#nullable disable

namespace OKR_Steam.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OKR_Steam.Models.DBModels.SteamProfileDatabaseModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("primaryclanid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("profilestate")
                        .HasColumnType("int");

                    b.Property<string>("profileurl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("steamid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("uniqueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SteamProfile");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using game_shop.Data;

#nullable disable

namespace game_shop.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240520045631_GameSeed")]
    partial class GameSeed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("game_shop.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "description",
                            Image = "image",
                            Name = "name",
                            Price = 69.989999999999995
                        },
                        new
                        {
                            Id = 2,
                            Description = "description2",
                            Image = "image2",
                            Name = "name2",
                            Price = 69.989999999999995
                        },
                        new
                        {
                            Id = 3,
                            Description = "description3",
                            Image = "image3",
                            Name = "name3",
                            Price = 69.989999999999995
                        },
                        new
                        {
                            Id = 4,
                            Description = "description4",
                            Image = "image4",
                            Name = "name4",
                            Price = 69.989999999999995
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

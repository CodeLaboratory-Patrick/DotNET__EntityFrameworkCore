﻿// <auto-generated />
using System;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCore.Data.Migrations
{
    [DbContext(typeof(FootballLeagueDbContext))]
    [Migration("20250218091259_SeededTeams")]
    partial class SeededTeams
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.2");

            modelBuilder.Entity("EntityFrameworkCore.Domain.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("EntityFrameworkCore.Domain.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamId = 1,
                            CreatedDate = new DateTime(2023, 1, 1, 1, 1, 1, 0, DateTimeKind.Utc),
                            Name = "Liverpool"
                        },
                        new
                        {
                            TeamId = 2,
                            CreatedDate = new DateTime(2023, 1, 1, 2, 2, 2, 0, DateTimeKind.Utc),
                            Name = "Arsenal"
                        },
                        new
                        {
                            TeamId = 3,
                            CreatedDate = new DateTime(2023, 1, 1, 3, 3, 3, 0, DateTimeKind.Utc),
                            Name = "Tottenham Hotspur"
                        },
                        new
                        {
                            TeamId = 4,
                            CreatedDate = new DateTime(2023, 1, 1, 4, 4, 4, 0, DateTimeKind.Utc),
                            Name = "Manchester City"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

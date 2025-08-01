﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyApi.Data;

#nullable disable

namespace MyApi2.Migrations
{
    [DbContext(typeof(BoschDbContext))]
    [Migration("20250729233250_adjustment")]
    partial class adjustment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyApi.Entities.Moviment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Destination")
                        .HasColumnType("int");

                    b.Property<int>("Origin")
                        .HasColumnType("int");

                    b.Property<int>("PartId")
                        .HasColumnType("int");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("Moviments");
                });

            modelBuilder.Entity("MyApi.Entities.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CurStationId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CurStationId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("MyApi.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Sort = 1,
                            Title = "Estação Inicial"
                        },
                        new
                        {
                            Id = 2,
                            Sort = 2,
                            Title = "Montagem"
                        },
                        new
                        {
                            Id = 3,
                            Sort = 3,
                            Title = "Inspeção"
                        });
                });

            modelBuilder.Entity("MyApi.Entities.Moviment", b =>
                {
                    b.HasOne("MyApi.Entities.Part", "Part")
                        .WithMany("Moviments")
                        .HasForeignKey("PartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Part");
                });

            modelBuilder.Entity("MyApi.Entities.Part", b =>
                {
                    b.HasOne("MyApi.Entities.Station", "CurStation")
                        .WithMany("Parts")
                        .HasForeignKey("CurStationId");

                    b.Navigation("CurStation");
                });

            modelBuilder.Entity("MyApi.Entities.Part", b =>
                {
                    b.Navigation("Moviments");
                });

            modelBuilder.Entity("MyApi.Entities.Station", b =>
                {
                    b.Navigation("Parts");
                });
#pragma warning restore 612, 618
        }
    }
}

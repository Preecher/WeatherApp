﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Repos;

namespace Weather.DataAccess.Migrations
{
    [DbContext(typeof(WeatherContext))]
    [Migration("20210113182744_MakeDataRequestParent")]
    partial class MakeDataRequestParent
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weather.Entities.DataRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ZipWeatherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZipWeatherId");

                    b.ToTable("DataRequest");
                });

            modelBuilder.Entity("Weather.Entities.ZipWeather", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cloud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Pressure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Temp")
                        .HasColumnType("float");

                    b.Property<double>("TempHigh")
                        .HasColumnType("float");

                    b.Property<double>("TempLow")
                        .HasColumnType("float");

                    b.Property<DateTime>("WeatherDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WeatherDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WindSpeed")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ZipWeather");
                });

            modelBuilder.Entity("Weather.Entities.DataRequest", b =>
                {
                    b.HasOne("Weather.Entities.ZipWeather", "ZipWeather")
                        .WithMany()
                        .HasForeignKey("ZipWeatherId");
                });
#pragma warning restore 612, 618
        }
    }
}
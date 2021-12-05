﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFBackEnd.Api.Data;

namespace TFBackEnd.Api.Migrations
{
    [DbContext(typeof(TFBackEndApiContext))]
    [Migration("20211205195625_InitNewMigration")]
    partial class InitNewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SensorTelefono", b =>
                {
                    b.Property<int>("SensoresId")
                        .HasColumnType("int");

                    b.Property<int>("TelefonosId")
                        .HasColumnType("int");

                    b.HasKey("SensoresId", "TelefonosId");

                    b.HasIndex("TelefonosId");

                    b.ToTable("SensorTelefono");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Instalacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<bool>("Exitosa")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("OperarioId")
                        .HasColumnType("int");

                    b.Property<int>("TelefonoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("OperarioId");

                    b.HasIndex("TelefonoId");

                    b.ToTable("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Operario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Operarios");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Sensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sensor");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Telefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("SensorTelefono", b =>
                {
                    b.HasOne("TFBackEnd.Api.Models.Sensor", null)
                        .WithMany()
                        .HasForeignKey("SensoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFBackEnd.Api.Models.Telefono", null)
                        .WithMany()
                        .HasForeignKey("TelefonosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Instalacion", b =>
                {
                    b.HasOne("TFBackEnd.Api.Models.App", "App")
                        .WithMany("Instalaciones")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFBackEnd.Api.Models.Operario", "Operario")
                        .WithMany("Instalaciones")
                        .HasForeignKey("OperarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TFBackEnd.Api.Models.Telefono", "Telefono")
                        .WithMany("Instalaciones")
                        .HasForeignKey("TelefonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");

                    b.Navigation("Operario");

                    b.Navigation("Telefono");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.App", b =>
                {
                    b.Navigation("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Operario", b =>
                {
                    b.Navigation("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Telefono", b =>
                {
                    b.Navigation("Instalaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
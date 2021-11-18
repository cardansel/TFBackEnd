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
    [Migration("20211118131333_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TFBackEnd.Api.Models.Instalaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Appsid")
                        .HasColumnType("int");

                    b.Property<bool>("Exitosa")
                        .HasColumnType("bit");

                    b.Property<int?>("Operariosid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idApps")
                        .HasColumnType("int");

                    b.Property<int>("idOperario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Appsid");

                    b.HasIndex("Operariosid");

                    b.ToTable("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Operarios", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Operarios");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Telefonos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InstalacionesId")
                        .HasColumnType("int");

                    b.Property<int>("idInstalacion")
                        .HasColumnType("int");

                    b.Property<string>("marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("modelo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("InstalacionesId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.apps", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("apps");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Instalaciones", b =>
                {
                    b.HasOne("TFBackEnd.Api.Models.apps", "Apps")
                        .WithMany("Instalaciones")
                        .HasForeignKey("Appsid");

                    b.HasOne("TFBackEnd.Api.Models.Operarios", "Operarios")
                        .WithMany("Instalaciones")
                        .HasForeignKey("Operariosid");

                    b.Navigation("Apps");

                    b.Navigation("Operarios");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Telefonos", b =>
                {
                    b.HasOne("TFBackEnd.Api.Models.Instalaciones", "Instalaciones")
                        .WithMany("Telefonos")
                        .HasForeignKey("InstalacionesId");

                    b.Navigation("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Instalaciones", b =>
                {
                    b.Navigation("Telefonos");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.Operarios", b =>
                {
                    b.Navigation("Instalaciones");
                });

            modelBuilder.Entity("TFBackEnd.Api.Models.apps", b =>
                {
                    b.Navigation("Instalaciones");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Biodigestor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biodigestor.Migrations.InputGas
{
    [DbContext(typeof(InputGasContext))]
    [Migration("20240614222253_NewInputGasMigration")]
    partial class NewInputGasMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biodigestor.Models.BiodigestorClass", b =>
                {
                    b.Property<int>("IdBiodiestor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdBiodigestor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBiodiestor"));

                    b.Property<string>("ModeloBiodigestor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreBiodigestor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolumenGas")
                        .HasColumnType("int");

                    b.HasKey("IdBiodiestor");

                    b.ToTable("Biodigestores", (string)null);
                });

            modelBuilder.Entity("Biodigestor.Models.InputGas", b =>
                {
                    b.Property<int>("IdInputGas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdInputGas");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInputGas"));

                    b.Property<double>("CantidadGasEntrada")
                        .HasColumnType("float")
                        .HasColumnName("CantidadGasEntrada");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaEntrada");

                    b.Property<int>("IdBiodigestor")
                        .HasColumnType("int")
                        .HasColumnName("IdBiodigestor");

                    b.HasKey("IdInputGas");

                    b.HasIndex("IdBiodigestor");

                    b.HasIndex("IdInputGas")
                        .IsUnique();

                    b.ToTable("InputGases", (string)null);
                });

            modelBuilder.Entity("Biodigestor.Models.InputGas", b =>
                {
                    b.HasOne("Biodigestor.Models.BiodigestorClass", "Biodigestor")
                        .WithMany()
                        .HasForeignKey("IdBiodigestor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Biodigestor");
                });
#pragma warning restore 612, 618
        }
    }
}
﻿// <auto-generated />
using System;
using Biodigestor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biodigestor.Migrations.OutputGas
{
    [DbContext(typeof(OutputGasContext))]
    [Migration("20240618163933_OutputGasMigracion")]
    partial class OutputGasMigracion
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
                    b.Property<int>("IdBiodigestor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdBiodigestor");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBiodigestor"));

                    b.Property<string>("ModeloBiodigestor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreBiodigestor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolumenGas")
                        .HasColumnType("int");

                    b.HasKey("IdBiodigestor");

                    b.ToTable("BiodigestorClass");
                });

            modelBuilder.Entity("Biodigestor.Models.OutputGas", b =>
                {
                    b.Property<int>("IdOutput")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdOutput");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOutput"));

                    b.Property<float>("CantidadGasSalida")
                        .HasColumnType("real");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBiodigestor")
                        .HasColumnType("int");

                    b.HasKey("IdOutput");

                    b.HasIndex("IdBiodigestor");

                    b.ToTable("OutputGases", (string)null);
                });

            modelBuilder.Entity("Biodigestor.Models.OutputGas", b =>
                {
                    b.HasOne("Biodigestor.Models.BiodigestorClass", "BiodigestorClass")
                        .WithMany()
                        .HasForeignKey("IdBiodigestor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BiodigestorClass");
                });
#pragma warning restore 612, 618
        }
    }
}

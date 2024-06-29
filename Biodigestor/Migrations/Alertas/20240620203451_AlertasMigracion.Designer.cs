﻿// <auto-generated />
using System;
using Biodigestor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biodigestor.Migrations.Alertas
{
    [DbContext(typeof(AlertasContext))]
    [Migration("20240620203451_AlertasMigracion")]
    partial class AlertasMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Biodigestor.Models.Alerta", b =>
                {
                    b.Property<int>("IdAlerta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdAlerta");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAlerta"));

                    b.Property<string>("DescripcionAlerta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaHoraAlerta")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdBiodigestor")
                        .HasColumnType("int");

                    b.Property<string>("NivelSeveridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TituloAlerta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAlerta");

                    b.HasIndex("IdAlerta")
                        .IsUnique();

                    b.HasIndex("IdBiodigestor");

                    b.ToTable("Alertas", (string)null);
                });

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

            modelBuilder.Entity("Biodigestor.Models.Alerta", b =>
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

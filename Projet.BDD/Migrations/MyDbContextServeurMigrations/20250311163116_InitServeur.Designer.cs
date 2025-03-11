﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet.BDD;

#nullable disable

namespace Projet.BDD.Migrations.MyDbContextServeurMigrations
{
    [DbContext(typeof(MyDbContextServeur))]
    [Migration("20250311163116_InitServeur")]
    partial class InitServeur
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projet.BDD.Entities.Serveur.Anomalie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOperation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Devise")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Erreur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("MontantOperation")
                        .HasColumnType("float");

                    b.Property<string>("NumeroCarteBancaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Anomalies");
                });

            modelBuilder.Entity("Projet.BDD.Entities.Serveur.Enregistrement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateOperation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Devise")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MontantOperation")
                        .HasColumnType("float");

                    b.Property<string>("NumeroCarteBancaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeOperation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Enregistrements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOperation = new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Devise = "€",
                            MontantOperation = 500.0,
                            NumeroCarteBancaire = "4974 0185 0223 0000",
                            TypeOperation = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

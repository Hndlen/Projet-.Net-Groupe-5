using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.BDD.Migrations
{
    /// <inheritdoc />
    public partial class InitServeur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anomalies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarteBancaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantOperation = table.Column<double>(type: "float", nullable: true),
                    TypeOperation = table.Column<int>(type: "int", nullable: true),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tauxConvertion = table.Column<double>(type: "float", nullable: true),
                    Erreur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomalies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enregistrements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCarteBancaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontantOperation = table.Column<double>(type: "float", nullable: false),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tauxConvertion = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enregistrements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Enregistrements",
                columns: new[] { "Id", "DateOperation", "Devise", "MontantOperation", "NumeroCarteBancaire", "TypeOperation", "tauxConvertion" },
                values: new object[] { 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "€", 500.0, "4974 0185 0223 0000", 1, 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anomalies");

            migrationBuilder.DropTable(
                name: "Enregistrements");
        }
    }
}

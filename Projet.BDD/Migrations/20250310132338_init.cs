using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projet.BDD.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Libelle = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Libelle);
                });

            migrationBuilder.CreateTable(
                name: "Anomalies",
                columns: table => new
                {
                    NumeroCarteBancaire = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MontantOperation = table.Column<double>(type: "float", nullable: true),
                    TypeOperation = table.Column<int>(type: "int", nullable: true),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Erreur = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anomalies", x => x.NumeroCarteBancaire);
                });

            migrationBuilder.CreateTable(
                name: "Enregistrements",
                columns: table => new
                {
                    NumeroCarteBancaire = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MontantOperation = table.Column<double>(type: "float", nullable: false),
                    TypeOperation = table.Column<int>(type: "int", nullable: false),
                    DateOperation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Devise = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enregistrements", x => x.NumeroCarteBancaire);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AdresseClientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutJuridique = table.Column<int>(type: "int", nullable: true),
                    AdresseSiegeLibelle = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Adresses_AdresseClientId",
                        column: x => x.AdresseClientId,
                        principalTable: "Adresses",
                        principalColumn: "Libelle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Adresses_AdresseSiegeLibelle",
                        column: x => x.AdresseSiegeLibelle,
                        principalTable: "Adresses",
                        principalColumn: "Libelle");
                });

            migrationBuilder.CreateTable(
                name: "ComptesBancaire",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    TitulaireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesBancaire", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_ComptesBancaire_Clients_TitulaireId",
                        column: x => x.TitulaireId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartesBancaire",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompteBancaireNumero = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartesBancaire", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_CartesBancaire_ComptesBancaire_CompteBancaireNumero",
                        column: x => x.CompteBancaireNumero,
                        principalTable: "ComptesBancaire",
                        principalColumn: "Numero");
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Libelle", "CodePostal", "Complement", "Ville" },
                values: new object[] { "12, rue des Oliviers", 94000, "", "CRETEIL" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 1, "12, rue des Oliviers", new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bety@gmail.com", "BETY", "Daniel", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CartesBancaire_CompteBancaireNumero",
                table: "CartesBancaire",
                column: "CompteBancaireNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseClientId",
                table: "Clients",
                column: "AdresseClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseSiegeLibelle",
                table: "Clients",
                column: "AdresseSiegeLibelle");

            migrationBuilder.CreateIndex(
                name: "IX_ComptesBancaire_TitulaireId",
                table: "ComptesBancaire",
                column: "TitulaireId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anomalies");

            migrationBuilder.DropTable(
                name: "CartesBancaire");

            migrationBuilder.DropTable(
                name: "Enregistrements");

            migrationBuilder.DropTable(
                name: "ComptesBancaire");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Adresses");
        }
    }
}

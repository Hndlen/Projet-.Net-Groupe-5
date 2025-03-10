using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<int>(type: "int", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
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
                    AdresseClientId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatutJuridique = table.Column<int>(type: "int", nullable: true),
                    AdresseSiegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Adresses_AdresseClientId",
                        column: x => x.AdresseClientId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Adresses_AdresseSiegeId",
                        column: x => x.AdresseSiegeId,
                        principalTable: "Adresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComptesBancaire",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComptesBancaire", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_ComptesBancaire_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartesBancaire",
                columns: table => new
                {
                    Numero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompteCarteNumero = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartesBancaire", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_CartesBancaire_ComptesBancaire_CompteCarteNumero",
                        column: x => x.CompteCarteNumero,
                        principalTable: "ComptesBancaire",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "Id", "CodePostal", "Complement", "Libelle", "Ville" },
                values: new object[,]
                {
                    { 1, 94000, "", "12, rue des Oliviers", "CRETEIL" },
                    { 2, 94120, "Digicode 1432", "125, rue LaFayette", "FONTENAY SOUS BOIS" },
                    { 3, 94300, "Etage 2", "10, rue des Olivies", "VINCENNES" },
                    { 4, 93500, "", "36, quai des Orfèvres", "ROISSY EN FRANCE" },
                    { 5, 94120, "", "15, rue de la République", "FONTENAY SOUS BOIS" },
                    { 6, 75002, "Bat. C", "32, rue E. Renan", "PARIS" },
                    { 7, 92100, "", "25, rue de la Paix", "LA DEFENSE" },
                    { 8, 92100, "", "23, av P. Valery", "LA DEFENSE" },
                    { 9, 93500, "", "3, avenue des Parcs", "ROISSY EN France" },
                    { 10, 75003, "Fond de Cour", "15, Place de la Bastille", "PARIS" },
                    { 11, 93200, "", "3, rue Lecourbe", "BAGNOLET" },
                    { 12, 92060, "", "10, esplanade de la Défense", "LA DEFENSE" },
                    { 13, 92060, "Tour Franklin", "24, esplanade de la Défense", "LA DEFENSE" },
                    { 14, 75008, "", "10, rue de la Paix", "PARIS" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 1, 1, new DateTime(1985, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bety@gmail.com", "BETY", "Daniel", 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "AdresseSiegeId", "Discriminator", "Mail", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 2, 2, 2, "ClientProfessionnel", "info@axa.fr", "AXA", "12548795641122", 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 3, 3, new DateTime(1965, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bodin@gmail.com", "BODIN", "Justin", 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "AdresseSiegeId", "Discriminator", "Mail", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 4, 4, 12, "ClientProfessionnel", "info@paul.fr", "PAUL", "87459564455444", 3 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 5, 5, new DateTime(1977, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "berris@gmail.com", "BERRIS", "Karine", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "AdresseSiegeId", "Discriminator", "Mail", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 6, 6, 6, "ClientProfessionnel", "contact@primark.fr", "PRIMARK", "08755897458455", 0 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 7, 7, new DateTime(1977, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "abenir@gmail.com", "ABENIR", "Alexandra", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "AdresseSiegeId", "Discriminator", "Mail", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 8, 8, 13, "ClientProfessionnel", "info@zara.fr", "ZARA", "65895874587854", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 9, 9, new DateTime(1976, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "bensaid@gmail.com", "BENSAID", "Georgia", 1 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "AdresseSiegeId", "Discriminator", "Mail", "Nom", "Siret", "StatutJuridique" },
                values: new object[] { 10, 10, 14, "ClientProfessionnel", "contact@leonidas.fr", "LEONIDAS", "91235987456832", 2 });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdresseClientId", "DateNaissance", "Discriminator", "Mail", "Nom", "Prenom", "Sexe" },
                values: new object[] { 11, 11, new DateTime(1970, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ClientParticulier", "ababou@gmail.com", "ABABOU", "Teddy", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_CartesBancaire_CompteCarteNumero",
                table: "CartesBancaire",
                column: "CompteCarteNumero");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseClientId",
                table: "Clients",
                column: "AdresseClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AdresseSiegeId",
                table: "Clients",
                column: "AdresseSiegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ComptesBancaire_ClientId",
                table: "ComptesBancaire",
                column: "ClientId",
                unique: true);
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

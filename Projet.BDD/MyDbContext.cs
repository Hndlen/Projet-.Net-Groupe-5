using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD
{
    class MyDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientParticulier> ClientsParticulier { get; set; }
        public DbSet<ClientProfessionnel> ClientsProfessionnel { get; set; }
        public DbSet<CompteBancaire> ComptesBancaire { get; set; }
        public DbSet<CarteBancaire> CartesBancaire { get; set; }
        public DbSet<Enregistrement> Enregistrements { get; set; }
        public DbSet<Anomalie> Anomalies { get; set; }

        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbProjetGrp5;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //TPT
            //modelBuilder.Entity<Product>().ToTable<Product>("Products");
            //modelBuilder.Entity<ElectronicsProduct>().ToTable("ElectronicsProducts");
            // modelBuilder.Entity<FoodProduct>().ToTable("FoodProducts");

            //base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Category>()
                .HasIndex(c => c.Title)
                .IsUnique();*/

            /*modelBuilder.Entity<Client>()
                .HasOne(a => a.Adresse)
                .WithOne(c => c.Client)
                .HasForeignKey<Client>(c => c.AdresseId);*/


            //**************************************
            //* Adresse Clients Particulier
            //**************************************

            //Adresse 1 _ 12, rue des Oliviers
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "12, rue des Oliviers",
                      Complement = "",
                      CodePostal = 94000,
                      Ville = "CRETEIL"
                  });

            //Adresse 3 _ 10, rue des Olivies
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "10, rue des Olivies",
                      Complement = "Etage 2",
                      CodePostal = 94300,
                      Ville = "VINCENNES"
                  });

            //Adresse 5 _ 15, rue de la République
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "15, rue de la République",
                      Complement = "",
                      CodePostal = 94120,
                      Ville = "FONTENAY SOUS BOIS"
                  });

            //Adresse 7 _ 25, rue de la Paix
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "25, rue de la Paix",
                      Complement = "",
                      CodePostal = 92100,
                      Ville = "LA DEFENSE"
                  });

            //Adresse 9 _ 25, 3, avenue des Parcs
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "3, avenue des Parcs",
                      Complement = "",
                      CodePostal = 93500,
                      Ville = "ROISSY EN France"
                  });

            //Adresse 9 _ 25, 3, avenue des Parcs
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "3, rue Lecourbe",
                      Complement = "",
                      CodePostal = 93200,
                      Ville = "BAGNOLET"
                  });

            //**************************************
            //* Adresse Clients Professionnel
            //**************************************

            //Adresse 2 _ 125, rue LaFayette
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "125, rue LaFayette",
                      Complement = "Digicode 1432",
                      CodePostal = 94120,
                      Ville = "FONTENAY SOUS BOIS"
                  });
            //Siege _ 125, rue LaFayette
            

            //Adresse 4 _ 36, quai des Orfèvres
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "36, quai des Orfèvres",
                      Complement = "",
                      CodePostal = 93500,
                      Ville = "ROISSY EN FRANCE"
                  });
            //Siege _ 10, esplanade de la Défense
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "10, esplanade de la Défense",
                      Complement = "",
                      CodePostal = 92060,
                      Ville = "LA DEFENSE"
                  });

            //Adresse 6 _ 32, rue E. Renan
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "32, rue E. Renan",
                      Complement = "Bat. C",
                      CodePostal = 75002,
                      Ville = "PARIS"
                  });
            //Siege _ 32, rue E. Renan
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "23, av P. Valery",
                      Complement = "",
                      CodePostal = 92100,
                      Ville = "LA DEFENSE"
                  });

            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "24, esplanade de la Défense",
                      Complement = "Tour Franklin",
                      CodePostal = 92060,
                      Ville = "LA DEFENSE"
                  });

            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "15, Place de la Bastille",
                      Complement = "Fond de Cour",
                      CodePostal = 75003,
                      Ville = "PARIS"
                  });

            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Libelle = "10, rue de la Paix",
                      Complement = "",
                      CodePostal = 75008,
                      Ville = "PARIS"
                  });




            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 1,
                      Nom = "BETY",
                      AdresseClientId = "12, rue des Oliviers",
                      Mail = "bety@gmail.com",
                      Prenom = "Daniel",
                      Sexe = EnumSexe.Masculin,
                      DateNaissance = new DateTime(1985, 11, 12)
                  });

            /*modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 2,
                      Nom = "AXA",
                      AdresseClient = new Adresse("125, rue LaFayette", "Digicode 1432", 94120, "FONTENAY SOUS BOIS"),
                      Mail = "info@axa.fr",
                      Siret = "12548795641122",
                      StatutJuridique = EnumStatutJuridique.SARL,
                      AdresseSiege = new Adresse("125, rue LaFayette", "Digicode 1432", 94120, "FONTENAY SOUS BOIS")
                  });*/

        }
    }
}

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

            modelBuilder.Entity<ClientProfessionnel>()
                .HasOne(c => c.AdresseClient)
                .WithMany()
                .HasForeignKey(c => c.AdresseClientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ClientProfessionnel>()
                .HasOne(c => c.AdresseSiege)
                .WithMany()
                .HasForeignKey(c => c.AdresseSiegeId)
                .OnDelete(DeleteBehavior.NoAction);

            //**************************************
            //* Adresse Clients Particulier
            //**************************************

            //Adresse 1 _ 12, rue des Oliviers
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 1,
                      Libelle = "12, rue des Oliviers",
                      Complement = "",
                      CodePostal = 94000,
                      Ville = "CRETEIL"
                  });

            //Adresse 3 _ 10, rue des Olivies
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 3,
                      Libelle = "10, rue des Olivies",
                      Complement = "Etage 2",
                      CodePostal = 94300,
                      Ville = "VINCENNES"
                  });

            //Adresse 5 _ 15, rue de la République
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 5,
                      Libelle = "15, rue de la République",
                      Complement = "",
                      CodePostal = 94120,
                      Ville = "FONTENAY SOUS BOIS"
                  });

            //Adresse 7 _ 25, rue de la Paix
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 7,
                      Libelle = "25, rue de la Paix",
                      Complement = "",
                      CodePostal = 92100,
                      Ville = "LA DEFENSE"
                  });

            //Adresse 9 _ 3, avenue des Parcs
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 9,
                      Libelle = "3, avenue des Parcs",
                      Complement = "",
                      CodePostal = 93500,
                      Ville = "ROISSY EN France"
                  });

            //Adresse 11 _ 3, rue Lecourbe
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 11,
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
                      Id = 2,
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
                      Id = 4,
                      Libelle = "36, quai des Orfèvres",
                      Complement = "",
                      CodePostal = 93500,
                      Ville = "ROISSY EN FRANCE"
                  });
            //Siege _ 10, esplanade de la Défense
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 12,
                      Libelle = "10, esplanade de la Défense",
                      Complement = "",
                      CodePostal = 92060,
                      Ville = "LA DEFENSE"
                  });

            //Adresse 6 _ 32, rue E. Renan
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 6,
                      Libelle = "32, rue E. Renan",
                      Complement = "Bat. C",
                      CodePostal = 75002,
                      Ville = "PARIS"
                  });
            //Siege _ 32, rue E. Renan

            //Adresse 8 _ 23, av P. Valery
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 8,
                      Libelle = "23, av P. Valery",
                      Complement = "",
                      CodePostal = 92100,
                      Ville = "LA DEFENSE"
                  });

            //Siege _ 24, esplanade de la Défense
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 13,
                      Libelle = "24, esplanade de la Défense",
                      Complement = "Tour Franklin",
                      CodePostal = 92060,
                      Ville = "LA DEFENSE"
                  });

            //Adresse 10 _ 15, Place de la Bastille
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 10,
                      Libelle = "15, Place de la Bastille",
                      Complement = "Fond de Cour",
                      CodePostal = 75003,
                      Ville = "PARIS"
                  });

            //Siege _ 10, rue de la Paix
            modelBuilder.Entity<Adresse>()
                  .HasData(new Adresse
                  {
                      Id = 14,
                      Libelle = "10, rue de la Paix",
                      Complement = "",
                      CodePostal = 75008,
                      Ville = "PARIS"
                  });



            //**************************************
            //* Clients Particulier
            //**************************************
            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 1,
                      Nom = "BETY",
                      AdresseClientId = 1,
                      Mail = "bety@gmail.com",
                      Prenom = "Daniel",
                      Sexe = EnumSexe.Masculin,
                      DateNaissance = new DateTime(1985, 11, 12)
                  });

            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 3,
                      Nom = "BODIN",
                      AdresseClientId = 3,
                      Mail = "bodin@gmail.com",
                      Prenom = "Justin",
                      Sexe = EnumSexe.Masculin,
                      DateNaissance = new DateTime(1965, 5, 5)
                  });

            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 5,
                      Nom = "BERRIS",
                      AdresseClientId = 5,
                      Mail = "berris@gmail.com",
                      Prenom = "Karine",
                      Sexe = EnumSexe.Feminin,
                      DateNaissance = new DateTime(1977, 6, 6)
                  });

            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 7,
                      Nom = "ABENIR",
                      AdresseClientId = 7,
                      Mail = "abenir@gmail.com",
                      Prenom = "Alexandra",
                      Sexe = EnumSexe.Feminin,
                      DateNaissance = new DateTime(1977, 4, 12)
                  });

            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 9,
                      Nom = "BENSAID",
                      AdresseClientId = 9,
                      Mail = "bensaid@gmail.com",
                      Prenom = "Georgia",
                      Sexe = EnumSexe.Feminin,
                      DateNaissance = new DateTime(1976, 4, 16)
                  });

            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 11,
                      Nom = "ABABOU",
                      AdresseClientId = 11,
                      Mail = "ababou@gmail.com",
                      Prenom = "Teddy",
                      Sexe = EnumSexe.Masculin,
                      DateNaissance = new DateTime(1970, 10, 10)
                  });

            //**************************************
            //* Clients Professionnel
            //**************************************

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 2,
                      Nom = "AXA",
                      AdresseClientId = 2,
                      Mail = "info@axa.fr",
                      Siret = "12548795641122",
                      StatutJuridique = EnumStatutJuridique.SARL,
                      AdresseSiegeId = 2
                  });

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 4,
                      Nom = "PAUL",
                      AdresseClientId = 4,
                      Mail = "info@paul.fr",
                      Siret = "87459564455444",
                      StatutJuridique = EnumStatutJuridique.EURL,
                      AdresseSiegeId = 12
                  });

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 6,
                      Nom = "PRIMARK",
                      AdresseClientId = 6,
                      Mail = "contact@primark.fr",
                      Siret = "08755897458455",
                      StatutJuridique = EnumStatutJuridique.SARL,
                      AdresseSiegeId = 6
                  });

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 8,
                      Nom = "ZARA",
                      AdresseClientId = 8,
                      Mail = "info@zara.fr",
                      Siret = "65895874587854",
                      StatutJuridique = EnumStatutJuridique.SA,
                      AdresseSiegeId = 13
                  });

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 10,
                      Nom = "LEONIDAS",
                      AdresseClientId = 10,
                      Mail = "contact@leonidas.fr",
                      Siret = "91235987456832",
                      StatutJuridique = EnumStatutJuridique.SAS,
                      AdresseSiegeId = 14
                  });

        }
    }
}

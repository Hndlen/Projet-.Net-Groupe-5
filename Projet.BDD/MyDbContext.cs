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


            modelBuilder.Entity<ClientParticulier>()
                  .HasData(new ClientParticulier
                  {
                      Id = 1,
                      Nom = "BETY",
                      AdresseClient = new Adresse("12, rue des Oliviers", "", 94000, "CRETEIL"),
                      Mail = "bety@gmail.com",
                      Prenom = "Daniel",
                      Sexe = EnumSexe.Masculin,
                      DateNaissance = new DateTime(1985, 11, 12)
                  });

            modelBuilder.Entity<ClientProfessionnel>()
                  .HasData(new ClientProfessionnel
                  {
                      Id = 2,
                      Nom = "AXA",
                      AdresseClient = new Adresse("125, rue LaFayette", "Digicode 1432", 94120, "FONTENAY SOUS BOIS"),
                      Mail = "info@axa.fr",
                      Siret = "12548795641122",
                      StatutJuridique = EnumStatutJuridique.SARL,
                      AdresseSiege = new Adresse("125, rue LaFayette", "Digicode 1432", 94120, "FONTENAY SOUS BOIS")
                  });

        }
    }
}

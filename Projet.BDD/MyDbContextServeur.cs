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
    public class MyDbContextServeur : DbContext
    {
        public DbSet<Enregistrement> Enregistrements { get; set; }
        public DbSet<Anomalie> Anomalies { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbProjetServeur;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enregistrement>()
                  .HasData(new Enregistrement
                  {
                      Id = 1,
                      NumeroCarteBancaire = "4974 0185 0223 0000",
                      MontantOperation = 500,
                      TypeOperation = EnumOperation.Depot,
                      DateOperation = new DateTime(2024,03,10),
                      Devise = "€"
                  });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Projet.BDD
{
    public class MyDbContextConsole : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientParticulier> ClientsParticulier { get; set; }
        public DbSet<ClientProfessionnel> ClientsProfessionnel { get; set; }
        public DbSet<CompteBancaire> ComptesBancaire { get; set; }
        public DbSet<CarteBancaire> CartesBancaire { get; set; }

        public DbSet<CompteAdmin> ComptesAdmins { get; set; }

        public DbSet<TransactionsHistorique> TransactionsHistoriques { get; set; }
        //public DbSet<Anomalie> Anomalies { get; set; }

        public DbSet<Adresse> Adresses { get; set; }
        public int countCarte=0;
        public List<string> listCarte = new List<string> {
            "4974 0185 0223 9888",
            "4974 0185 0223 0457",
            "4974 0185 0223 0952",
            "4974 0185 0223 8476",
            "4974 0185 0223 8666",
            "4974 0185 0223 7411",
            "4974 0185 0223 4814",
            "4974 0185 0223 7320",
            "4974 0185 0223 5142",
            "4974 0185 0223 7874",
            "4974 0185 0223 6090",
            "4974 0185 0223 3469",
            "4974 0185 0223 5720",
            "4974 0185 0223 2842",
            "4974 0185 0223 9763",
            "4974 0185 0223 4871",
            "4974 0185 0223 6215",
            "4974 0185 0223 0150",
            "4974 0185 0223 2198",
            "4974 0185 0223 8096",
            "4974 0185 0223 1158",
            "4974 0185 0223 5290",
            "4974 0185 0223 1851",
            "4974 0185 0223 1869",
            "4974 0185 0223 5365",
            "4974 0185 0223 2271",
            "4974 0185 0223 4889",
            "4974 0185 0223 5258",
            "4974 0185 0223 8914",
            "4974 0185 0223 9375"};
        //public List<int> listCarte = new List<int> {};

        public HashSet<int> listCarteTest = new HashSet<int> {};

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbProjetConsole;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        }
       /* protected void GenerationCarteBancaire()
        {

            for (int i = 0; i < 10000; i++)
            {
                this.listCarte.Add(i);
            }
        }*/
        protected string RandomCarteBancaire()
        {
            if (this.listCarte.Count > 0) // Vérifier que la liste n'est pas vide
            {
                //Random random = new Random();
                //int index = random.Next(this.listCarte.Count); // Sélection aléatoire d'un index
                int index = 0; // Sélection aléatoire d'un index
                string valeurSupprimee = this.listCarte[index];  // Récupérer la valeur avant suppression

                this.listCarte.RemoveAt(index); // Supprimer l'élément
                return valeurSupprimee;
            }
            else
            {
                return null;
            }
        }

        /*
        protected void GenerationCarteBancaire(ModelBuilder modelBuilder)
        {

            

            for (int i = 0; i < 10000; i++)
            {
                modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          Numero = $"4974 0185 0223 {i.ToString("D4")}"

                      });
            }
        }*/

        protected void OuvertureCompteClient(ModelBuilder modelBuilder,int idClient, int CP , DateTime dateOuverture, int nbCarte)
        {
            string dateO = dateOuverture.ToString("yyyy MMdd");
            string ID = idClient.ToString("D4").Substring(0, 4);
            string newNumero = $"HNTB {ID} {dateO} {CP.ToString().Substring(0,4)}";
            //int numCarte = 0;
            string numCarteValide;
            modelBuilder.Entity<CompteBancaire>()
                  .HasData(new CompteBancaire
                  {
                      Numero = newNumero,
                      DateOuverture = dateOuverture,
                      Solde = 1000,
                      ClientId = idClient
                  });
            for (int i = 0; i < nbCarte; i++)
            {
                //numCarte = RandomCarteBancaire();
                numCarteValide = RandomCarteBancaire();
                modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          //Numero = $"4974 0185 0223 {numCarte.ToString("D4")}",
                          Numero = numCarteValide,
                          CompteCarteId = newNumero,

                      });
                //this.countCarte++;
            }
        }

        protected string GenererNumeroCompte(DateTime dateOuverture)
        {
            string date = dateOuverture.ToString("yyyy MMdd");
            Random random = new Random();
            string compte = random.Next(1000, 9999).ToString(); // 4 chiffres aléatoires
            
            return $"HNTB-{date}-{compte}";
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Random random = new Random();
            //string compte = random.Next(1000, 9999).ToString(); // 4 chiffres aléatoires
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
            //* TEST COMPTE BANCAIRE + CARTE
            //**************************************
            //GenerationCarteBancaire(modelBuilder);

            //DateTime dateOuverture = new DateTime(2000, 11, 12);
            //string test = GenererNumeroCompte(dateOuverture);

           /* byte[] randomBytes = new byte[4];
            RandomNumberGenerator.Fill(randomBytes);
            int randomNumber = BitConverter.ToInt32(randomBytes, 0) & int.MaxValue; // Valeur positive
            randomNumber = randomNumber % 10000;*/
            //string randomNumber = "HNTB 0000";

            /*modelBuilder.Entity<CompteBancaire>()
                  .HasData(new CompteBancaire
                  {
                      //Numero = "HNTB 0000",
                      Numero = randomNumber.ToString(),
                      DateOuverture = new DateTime(2000, 11, 12),
                      //DateOuverture = new DateTime(2000, 11, 12),
                      Solde = 1000,
                      ClientId = 1

                  });
            
            modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          Numero = $"4974 0185 0223 0000",
                          //CompteCarteId = "HNTB 0000"
                          CompteCarteId = randomNumber.ToString(),

                      });*/
            /*
            modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          Numero = $"4974 0185 0223 0001",
                          CompteCarteId = "HNTB 0000",

                      });
            DateTime dateOuverture1 = new DateTime(2021, 11, 12);
            string test1 = "HNTB 0001";
            modelBuilder.Entity<CompteBancaire>()
                  .HasData(new CompteBancaire
                  {
                      
                      Numero = "HNTB 0001",
                      DateOuverture = dateOuverture1,
                      Solde = 1000,
                      ClientId = 2

                  });
            modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          Numero = $"4974 0185 0223 0003",
                          CompteCarteId = test1,

                      });
            DateTime dateOuverture2 = new DateTime(2010, 11, 12);
            string test2 = "HNTB 0002";
            modelBuilder.Entity<CompteBancaire>()
                  .HasData(new CompteBancaire
                  {

                      Numero = test2,
                      DateOuverture = dateOuverture2,
                      Solde = 1000,
                      ClientId = 3

                  });
            modelBuilder.Entity<CarteBancaire>()
                      .HasData(new CarteBancaire
                      {
                          Numero = $"4974 0185 0223 0004",
                          CompteCarteId = test2,

                      });

            //************************************
            */


            /*modelBuilder.Entity<CompteBancaire>()
                  .HasData(new CompteBancaire
                  {
                      
                  });*/


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
            //GenerationCarteBancaire();

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
            OuvertureCompteClient(modelBuilder, 1, 94000,  new DateTime(2000, 11, 12), 1);

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
            OuvertureCompteClient(modelBuilder, 3, 94300,  new DateTime(2005, 11, 12), 2);

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
            OuvertureCompteClient(modelBuilder, 5, 94120,  new DateTime(2014, 12, 12), 2);

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
            OuvertureCompteClient(modelBuilder, 7, 92100, new DateTime(2022, 12, 12), 1);
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
            OuvertureCompteClient(modelBuilder, 9, 93500,  new DateTime(1999, 4, 16), 1);
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
            OuvertureCompteClient(modelBuilder, 2, 94120, new DateTime(1999, 4, 16), 1);

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
            OuvertureCompteClient(modelBuilder, 4, 93500, new DateTime(2020, 2, 15), 2);

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
            OuvertureCompteClient(modelBuilder, 6, 75002, new DateTime(2021, 3, 15), 2);

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
            OuvertureCompteClient(modelBuilder, 8, 92100, new DateTime(2019, 3, 23), 2);
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
            OuvertureCompteClient(modelBuilder, 10, 75003, new DateTime(2015, 7, 19), 2);

        }
    }
}

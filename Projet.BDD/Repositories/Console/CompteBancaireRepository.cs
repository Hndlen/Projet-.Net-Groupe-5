using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    public class CompteBancaireRepository : Irepository<CompteBancaire>
    {
        public CompteBancaireRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContextConsole();
            context.Database.EnsureCreated();
        }
        public async Task<List<CompteBancaire>> getAll()
        {
            using var context = new MyDbContextConsole();
            var compteBancaires = await context.ComptesBancaire.ToListAsync<CompteBancaire>();
            return compteBancaires;
        }

        public async Task<CompteBancaire?> GetbyId(string numero)
        {
            using var context = new MyDbContextConsole();
            var compteBancaire = await context.ComptesBancaire
                            .Where<CompteBancaire>(cb => cb.Numero == numero)
                            .SingleOrDefaultAsync<CompteBancaire>();
            return compteBancaire;
        }


        public async Task<int> Add(CompteBancaire catEntity)
        {
            using var context = new MyDbContextConsole();
            context.ComptesBancaire.Add(catEntity);
            var cbSaved = await context.SaveChangesAsync();
            return cbSaved;

        }

        public async Task<int> MajSolde(string numero, double montant)
        {
            using var context = new MyDbContextConsole();

            var compteBancaire = await context.ComptesBancaire
                .Where(cb => cb.Numero == numero)
                .SingleOrDefaultAsync();

            if (compteBancaire == null)
            {
                // Si le compte n'existe pas, retourne une valeur indiquant l'échec (par exemple -1)
                return -1;
            }

            // Mettre à jour le solde du compte
            compteBancaire.Solde += montant;

            // Enregistrer les changements dans la base de données
            var result = await context.SaveChangesAsync();

            return result;
        }
    }

}

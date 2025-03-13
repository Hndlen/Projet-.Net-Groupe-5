using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    public class CompteAdminRepository : Irepository<CompteAdmin>
    {
        public CompteAdminRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContextConsole();
            context.Database.EnsureCreated();
        }
        public async Task<List<CompteAdmin>> getAll()
        {
            using var context = new MyDbContextConsole();
            var clients = await context.ComptesAdmins.ToListAsync<CompteAdmin>();

            return clients;
        }

        public async Task<bool> Connexion(string id, string mdp)
        {
            using var context = new MyDbContextConsole();
            var admin = await context.ComptesAdmins
                            .Where<CompteAdmin>(c => c.Identifiant == id && c.Mdp == mdp )
                            .SingleOrDefaultAsync<CompteAdmin>();
            return (admin != null);
        }

    }
}

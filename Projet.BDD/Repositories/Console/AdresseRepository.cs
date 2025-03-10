using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    public class AdresseRepository : Irepository<Adresse>
    {
        public AdresseRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }
        public async Task<List<Adresse>> getAll()
        {
            using var context = new MyDbContext();
            var adresses = await context.Adresses.ToListAsync<Adresse>();
            return adresses;
        }

        public async Task<Adresse?> GetbyId(int id)
        {
            using var context = new MyDbContext();
            var adresse = await context.Adresses
                            .Where<Adresse>(a => a.Id == id)
                            .SingleOrDefaultAsync<Adresse>();
            return adresse;
        }

        public async Task<int> Add(Adresse addEntity)
        {
            using var context = new MyDbContext();
            context.Adresses.Add(addEntity);
            var adrSaved = await context.SaveChangesAsync();
            return adrSaved;

        }
    }
}


using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Serveur
{
    public class EnregistrementRepository : Irepository<Enregistrement>
    {
        public EnregistrementRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }
        public async Task<List<Enregistrement>> getAll()
        {
            using var context = new MyDbContext();
            var enregistrements = await context.Enregistrements.ToListAsync<Enregistrement>();
            return enregistrements;
        }

        public async Task<Enregistrement?> GetbyNumCarte(string numero)
        {
            using var context = new MyDbContext();
            var enregistrement = await context.Enregistrements
                            .Where<Enregistrement>(e => e.NumeroCarteBancaire == numero)
                            .SingleOrDefaultAsync<Enregistrement>();
            return enregistrement;
        }

        public async Task<List<Enregistrement?>> GetbyTypeOp(EnumOperation typeOp)
        {
            using var context = new MyDbContext();
            var enregistrement = await context.Enregistrements
                            .Where<Enregistrement>(e => e.TypeOperation == typeOp)
                            .ToListAsync<Enregistrement>();
            return enregistrement;
        }

        public async Task<int> Add(Enregistrement catEntity)
        {
            using var context = new MyDbContext();
            context.Enregistrements.Add(catEntity);
            var enrSaved = await context.SaveChangesAsync();
            return enrSaved;

        }
    }
}

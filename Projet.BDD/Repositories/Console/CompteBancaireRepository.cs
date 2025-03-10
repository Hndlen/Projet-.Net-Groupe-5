﻿using Projet.BDD.Entities.Console;
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
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }
        public async Task<List<CompteBancaire>> getAll()
        {
            using var context = new MyDbContext();
            var compteBancaires = await context.CompteBancaires.ToListAsync<CompteBancaire>();
            return compteBancaires;
        }

        public async Task<CompteBancaire?> GetbyId(int id)
        {
            using var context = new MyDbContext();
            var compteBancaire = await context.CompteBancaires
                            .Where<CompteBancaire>(cb => cb.Id == id)
                            .SingleOrDefaultAsync<CompteBancaire>();
            return compteBancaire;
        }


        public async Task<int> Add(CompteBancaire catEntity)
        {
            using var context = new MyDbContext();
            context.CompteBancaires.Add(catEntity);
            var cbSaved = await context.SaveChangesAsync();
            return cbSaved;

        }
    }

}

using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    class TransactionsHistoriqueRepository : Irepository<TransactionsHistorique>
    {
        public TransactionsHistoriqueRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContextConsole();
            context.Database.EnsureCreated();
        }
        public async Task<List<TransactionsHistorique>> getAll()
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques.ToListAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }
        public async Task<TransactionsHistorique> getById(int id)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                                    .Where<TransactionsHistorique>(e => e.Id == id)
                                    .SingleOrDefaultAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }

        public async Task<TransactionsHistorique?> GetbyNumCarte(string numero)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                            .Where<TransactionsHistorique>(e => e.NumeroCarteBancaire == numero)
                            .SingleOrDefaultAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }

        public async Task<List<TransactionsHistorique?>> GetbyTypeOp(EnumOperation typeOp)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                            .Where<TransactionsHistorique>(e => e.TypeOperation == typeOp)
                            .ToListAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }

        public async Task<int> Add(TransactionsHistorique catEntity)
        {
            using var context = new MyDbContextConsole();
            context.TransactionsHistoriques.Add(catEntity);
            var enrSaved = await context.SaveChangesAsync();
            return enrSaved;

        }
    }
}

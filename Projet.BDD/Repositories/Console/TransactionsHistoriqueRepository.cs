﻿using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Projet.BDD.Repositories.Console
{
    public class TransactionsHistoriqueRepository : Irepository<TransactionsHistorique>
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
        
        public async Task<TransactionsHistorique?> GetbyNumCarte(string numeroCarte)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                            .Where<TransactionsHistorique>(e => e.NumeroCarteBancaire == numeroCarte)
                            .SingleOrDefaultAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }

        public async Task<List<TransactionsHistorique?>> GetbyTypeOp(string typeOp)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                            .Where<TransactionsHistorique>(e => e.TypeOperation == typeOp)
                            .ToListAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }

        public async Task<List<TransactionsHistorique?>> GetByDateBetween(DateTime debut, DateTime fin)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistoriques = await context.TransactionsHistoriques
                                    .Where(e => e.DateOperation.Date >= debut.Date && e.DateOperation.Date <= fin.Date)
                                    .ToListAsync();
            return transactionsHistoriques;
        }
        public async Task<List<TransactionsHistorique?>> GetbyNumCompteBetween(string numeroCompte, DateTime debut, DateTime fin)
        {
            using var context = new MyDbContextConsole();
            var transactionsHistorique = await context.TransactionsHistoriques
                            .Where<TransactionsHistorique>(e => e.CompteCarteId == numeroCompte && e.DateOperation.Date >= debut.Date && e.DateOperation.Date <= fin.Date)
                            .ToListAsync<TransactionsHistorique>();
            return transactionsHistorique;
        }
        public async Task<List<TransactionsHistorique?>> GetByDateBetweenByNumCB(DateTime debut, DateTime fin, string NumeroCarteBancaire)
        {
            //DateTime date1 = DateTime.Parse("2001-01-01", CultureInfo.InvariantCulture);
            //DateTime date2 = DateTime.Parse("2009-01-01", CultureInfo.InvariantCulture);
            //System.Console.WriteLine(date1.ToString());
            using var context = new MyDbContextConsole();
            var transactionsHistoriques = await context.TransactionsHistoriques
                                    .Where(e => e.DateOperation.Date >= debut.Date && e.DateOperation.Date <= fin.Date && e.NumeroCarteBancaire == NumeroCarteBancaire)
                                    .ToListAsync();
            return transactionsHistoriques;
        }


        public int Add(TransactionsHistorique catEntity)
        {
            using var context = new MyDbContextConsole();
            var ok = context.TransactionsHistoriques.Add(catEntity);
            var enrSaved = context.SaveChanges();
            return enrSaved;

        }
    }
}

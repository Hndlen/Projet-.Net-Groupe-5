using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities;
using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    public class ClientRepository : Irepository<Client>
    {
            public ClientRepository()
            {
                InitializeDatabase();
            }

            private void InitializeDatabase()
            {
                using var context = new MyDbContextConsole();
                context.Database.EnsureCreated();
            }
            public async Task<List<Client>> getAll()
            {
                using var context = new MyDbContextConsole();
                var clients = await context.Clients
                                    .Include(c => c.CompteBancaire)
                                    .Include(c => c.AdresseClient)
                                    .ToListAsync<Client>();
                return clients;
            }

            public async Task<Client?> GetbyId(int id)
            {
                using var context = new MyDbContextConsole();
                var client = await context.Clients
                                .Where<Client>(c => c.Id == id)
                                .Include(c => c.CompteBancaire)
                                .Include(c => c.AdresseClient)
                                .SingleOrDefaultAsync<Client>();
                return client;
            }

            public async Task<Client?> GetbyType(string type)
            {
                using var context = new MyDbContextConsole();
                var client = await context.Clients
                                .Where<Client>(c => c.Type == type)
                                .Include(c => c.CompteBancaire)
                                .Include(c => c.AdresseClient)
                                .SingleOrDefaultAsync<Client>();
                return client;
            }

        public async Task<int> Add(Client catEntity)
            {
                using var context = new MyDbContextConsole();
                context.Clients.Add(catEntity);
                var cliSaved = await context.SaveChangesAsync();
                return cliSaved;

            }

        }
    }


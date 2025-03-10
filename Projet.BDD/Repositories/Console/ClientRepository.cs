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
                using var context = new MyDbContext();
                context.Database.EnsureCreated();
            }
            public async Task<List<Client>> getAll()
            {
                using var context = new MyDbContext();
                var clients = await context.Clients.ToListAsync<Client>();
                return clients;
            }

            public async Task<Client?> GetbyId(int id)
            {
                using var context = new MyDbContext();
                var client = await context.Clients
                                .Where<Client>(c => c.Id == id)
                                .SingleOrDefaultAsync<Client>();
                return client;
            }

            public async Task<Client?> GetbyType(string type)
            {
                using var context = new MyDbContext();
                var client = await context.Clients
                                .Where<Client>(c => c.Type == type)
                                .SingleOrDefaultAsync<Client>();
                return client;
            }

        public async Task<int> Add(Client catEntity)
            {
                using var context = new MyDbContext();
                context.clients.Add(catEntity);
                var cliSaved = await context.SaveChangesAsync();
                return cliSaved;

            }

        }
    }


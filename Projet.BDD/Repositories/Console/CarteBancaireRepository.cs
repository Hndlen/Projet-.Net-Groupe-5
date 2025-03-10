using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Console
{
    public class CarteBancaireRepository  : Irepository<CarteBancaire>
    {
        public CarteBancaireRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContextConsole();
            context.Database.EnsureCreated();
        }
        public async Task<List<CarteBancaire>> getAll()
        {
            using var context = new MyDbContextConsole();
            var carteBancaires = await context.CartesBancaire.ToListAsync<CarteBancaire>();
            return carteBancaires;
        }

        public async Task<CarteBancaire?> GetbyId(string num)
        {
            using var context = new MyDbContextConsole();
            var carteBancaire = await context.CartesBancaire
                            .Where<CarteBancaire>(cb => cb.Numero == num)
                            .SingleOrDefaultAsync<CarteBancaire>();
            return carteBancaire;
        }

        public async Task<int> Add(CarteBancaire catEntity)
        {
            using var context = new MyDbContextConsole();
            context.CartesBancaire.Add(catEntity);
            var cbSaved = await context.SaveChangesAsync();
            return cbSaved;

        }


    }
}

using Microsoft.EntityFrameworkCore;
using Projet.BDD.Entities.Serveur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.BDD.Repositories.Serveur
{
    public class AnomalieRepository :  Irepository<Anomalie>
    {
        public AnomalieRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var context = new MyDbContextServeur();
            context.Database.EnsureCreated();
        }
        public async Task<List<Anomalie>> getAll()
        {
            using var context = new MyDbContextServeur();
            var anomalies = await context.Anomalies.ToListAsync<Anomalie>();
            return anomalies;
        }

        public async Task<Anomalie> getById(int id)
        {
            using var context = new MyDbContextServeur();
            var enregistrements = await context.Anomalies
                                    .Where<Anomalie>(e => e.Id == id)
                                    .SingleOrDefaultAsync<Anomalie>();
            return enregistrements;
        }
        public async Task<Anomalie?> GetbyNumCarte(string numero)
        {
            using var context = new MyDbContextServeur();
            var enregistrement = await context.Anomalies
                            .Where<Anomalie>(a => a.NumeroCarteBancaire == numero)
                            .SingleOrDefaultAsync<Anomalie>();
            return enregistrement;
        }

        public async Task<List<Anomalie?>> GetbyTypeOp(EnumOperation typeOp)
        {
            using var context = new MyDbContextServeur();
            var enregistrement = await context.Anomalies
                            .Where<Anomalie>(a => a.TypeOperation == typeOp)
                            .ToListAsync<Anomalie>();
            return enregistrement;
        }

        public async Task<int> Add(Anomalie anoEntity)
        {
            using var context = new MyDbContextServeur();
            context.Anomalies.Add(anoEntity);
            var anoSaved = await context.SaveChangesAsync();
            return anoSaved;

        }
    }
}


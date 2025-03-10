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
            using var context = new MyDbContext();
            context.Database.EnsureCreated();
        }
        public async Task<List<Anomalie>> getAll()
        {
            using var context = new MyDbContext();
            var anomalies = await context.Anomalies.ToListAsync<Anomalie>();
            return anomalies;
        }

        public async Task<Anomalie?> GetbyNumCarte(string numero)
        {
            using var context = new MyDbContext();
            var enregistrement = await context.Anomalies
                            .Where<Anomalie>(a => a.numCB == numero)
                            .ToListAsync<Anomalie>();
            return enregistrement;
        }

        public async Task<Anomalie?> GetbyTypeOp(string typeOp)
        {
            using var context = new MyDbContext();
            var enregistrement = await context.Anomalies
                            .Where<Anomalie>(a => a.typeOp == typeOp)
                            .ToListAsync<Anomalie>();
            return enregistrement;
        }

        public async Task<int> Add(entity anoEntity)
        {
            using var context = new MyDbContext();
            context.Anomalies.Add(anoEntity);
            var anoSaved = await context.SaveChangesAsync();
            return anoSaved;

        }
    }
}


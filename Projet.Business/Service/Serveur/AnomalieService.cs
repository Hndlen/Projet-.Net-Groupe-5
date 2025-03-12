using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.BDD.Repositories.Console;
using Projet.BDD.Repositories.Serveur;
using Projet.Business.Dto;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service.Serveur
{
    public class AnomalieService
    {
        private readonly AnomalieRepository _repo;
        private readonly IMapper _mapper;

        public AnomalieService()
        {
            _repo = new AnomalieRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<AnomalieDto>> GetAnomalies()
        {
            var entities = await _repo.getAll();
            var dto = entities.Select(cat => _mapper.Map<AnomalieDto>(cat)).ToList<AnomalieDto>();
            return dto;
        }

        public async Task<AnomalieDto> GetAnomaliesById(int id)
        {
            var entities = await _repo.getById(id);
            var dto =  _mapper.Map<AnomalieDto>(entities);
            return dto;
        }

        public async Task<int> AddAnomalie(AnomalieDto dto)
        {
            var addEntity = _mapper.Map<Anomalie>(dto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }

    }
}

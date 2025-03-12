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
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<AnomalieDto>(cat)).ToList<AnomalieDto>();
            return addDto;
        }

        public async Task<AnomalieDto> GetAnomaliesById(int id)
        {
            var addEntities = await _repo.getById(id);
            var addDto =  _mapper.Map<AnomalieDto>(addEntities);
            return addDto;
        }

        public async Task<int> AddAnomalie(AnomalieDto addDto)
        {
            var addEntity = _mapper.Map<Anomalie>(addDto);
            var addSaved = await _repo.Add(addEntity);
            System.Console.WriteLine("AnomalieService");
            return addSaved;
        }

    }
}

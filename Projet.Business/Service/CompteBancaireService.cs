using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Repositories.Console;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service
{
    class CompteBancaireService
    {
        private readonly CompteBancaireRepository _repo;
        private readonly IMapper _mapper;

        public CompteBancaireService()
        {
            _repo = new CompteBancaireRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<CompteBancaireDto>> GetCompteBancaires()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<CompteBancaireDto>(cat)).ToList<CompteBancaireDto>();
            return addDto;
        }

        //public async Task<CategoryDto> GetCompteBancairessById(int id)
        //{
        //    var addEntities = await _repo.GetbyId(id);
        //    var catDto = _mapper.Map<CategoryDto>(catEntity);
        //    return catDto;
        //}

        public async Task<int> AddAdress(CompteBancaireDto addDto)
        {
            var addEntity = _mapper.Map<CompteBancaire>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}

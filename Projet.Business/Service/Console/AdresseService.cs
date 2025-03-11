using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Projet.BDD.Entities.Console;
using Projet.BDD.Repositories.Console;
using Projet.Business.Dto.Console;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service.Console
{
    public class AdresseService
    {
        private readonly AdresseRepository _repo;
        private readonly IMapper _mapper;

        public AdresseService()
        {
            _repo = new AdresseRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<AdresseDto>> GetAdresses()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<AdresseDto>(cat)).ToList();
            return addDto;
        }

        //public async Task<CategoryDto> GetAdressessById(int id)
        //{
        //    var addEntities = await _repo.GetbyId(id);
        //    var catDto = _mapper.Map<CategoryDto>(catEntity);
        //    return catDto;
        //}

        public async Task<int> AddAdress(AdresseDto addDto)
        {
            var addEntity = _mapper.Map<Adresse>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }

    
}

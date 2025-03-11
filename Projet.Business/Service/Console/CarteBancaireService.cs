using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Repositories.Console;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
using Recap.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Service.Console
{
    public class CarteBancaireService
    {
        private readonly CarteBancaireRepository _repo;
        private readonly IMapper _mapper;

        public CarteBancaireService()
        {
            _repo = new CarteBancaireRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<CarteBancaireDto>> GetCarteBancaires()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<CarteBancaireDto>(cat)).ToList();
            return addDto;
        }

        public async Task<CarteBancaireDto> GetCarteBancaireById(string id)
        {
            var addEntities = await _repo.GetbyId(id);
            var catDto = _mapper.Map<CarteBancaireDto>(addEntities);
            return catDto;
        }

        public async Task<int> AddCarteBancaire(CarteBancaireDto addDto)
        {
            var addEntity = _mapper.Map<CarteBancaire>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}


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
    public class ClientService
    {
        private readonly ClientRepository _repo;
        private readonly IMapper _mapper;

        public ClientService()
        {
            _repo = new ClientRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<ClientDto>> GetClients()
        {
            var addEntities = await _repo.getAll();
            var addDto = addEntities.Select(cat => _mapper.Map<ClientDto>(cat)).ToList<ClientDto>();
            return addDto;
        }

        //public async Task<CategoryDto> GetClientssById(int id)
        //{
        //    var addEntities = await _repo.GetbyId(id);
        //    var catDto = _mapper.Map<CategoryDto>(catEntity);
        //    return catDto;
        //}

        public async Task<int> AddAdress(ClientDto addDto)
        {
            var addEntity = _mapper.Map<Client>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}


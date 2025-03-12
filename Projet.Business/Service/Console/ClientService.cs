using AutoMapper;
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
            var cliEntities = await _repo.getAll();
            System.Console.WriteLine("Check Type");

            var cliDto = cliEntities.Select(cli =>
            {
                if (cli is ClientParticulier clientParticulier)
                {
                    System.Console.WriteLine("particulier : " + clientParticulier.Prenom);
                    return _mapper.Map<ClientParticulierDto>(clientParticulier);
                }
                else if (cli is ClientProfessionnel clientProfessionnel)
                {
                    System.Console.WriteLine("pro : " + clientProfessionnel.Siret);
                    return _mapper.Map<ClientProfessionnelDto>(clientProfessionnel);
                }
                else
                {
                    System.Console.WriteLine("simple client");
                    return _mapper.Map<ClientDto>(cli);
                }
            }).ToList<ClientDto>();

            return cliDto;
        }



        public async Task<ClientDto> GetClientById(int id)
        {
            var entities = await _repo.GetbyId(id);
            if (entities is ClientParticulier clientParticulier)
            {
                return _mapper.Map<ClientParticulierDto>(clientParticulier);
            }
            else if (entities is ClientProfessionnel clientProfessionnel)
            {
                return _mapper.Map<ClientProfessionnelDto>(clientProfessionnel);
            }
            else
            {
                return _mapper.Map<ClientDto>(entities);
            }
        }


        public async Task<int> AddClient(ClientDto addDto)
        {
            var addEntity = _mapper.Map<Client>(addDto);
            var addSaved = await _repo.Add(addEntity);
            return addSaved;
        }
    }
}


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
    public class CompteAdminService
    {
        private readonly CompteAdminRepository _repo;
        private readonly IMapper _mapper;

        public CompteAdminService()
        {
            _repo = new CompteAdminRepository();
            _mapper = MappingConfig.Mapper;

        }

        public async Task<List<CompteAdminDto>> GetCompteAdmins()
        {
            var entities = await _repo.getAll();
            var dto = entities.Select(cat => _mapper.Map<CompteAdminDto>(cat)).ToList();
            return dto;
        }

        public async Task<bool> Coonexion(string id, string mdp)
        {
            var succes = await _repo.Connexion(id,mdp);
            return succes;
        }

    }
}

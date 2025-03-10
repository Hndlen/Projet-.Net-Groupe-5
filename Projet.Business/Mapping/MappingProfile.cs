using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.Business.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet.Business.Mapping
{
    class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Adresse, AdresseDto>().ReverseMap();
            CreateMap<CarteBancaire, CarteBancaireDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientParticulier, ClientParticulierDto>().ReverseMap();
            CreateMap<ClientProfessionnel, ClientProfessionnelDto>().ReverseMap();
            CreateMap<CompteBancaire, CompteBancaireDto>().ReverseMap();

        }
    }
}


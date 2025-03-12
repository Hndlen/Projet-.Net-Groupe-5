using AutoMapper;
using Projet.BDD.Entities.Console;
using Projet.BDD.Entities.Serveur;
using Projet.Business.Dto;
using Projet.Business.Dto.Console;
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
            //application console
            CreateMap<Adresse, AdresseDto>().ReverseMap();
            CreateMap<CarteBancaire, CarteBancaireDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientParticulier, ClientParticulierDto>().ReverseMap();
            CreateMap<ClientProfessionnel, ClientProfessionnelDto>().ReverseMap();
            CreateMap<CompteBancaire, CompteBancaireDto>().ReverseMap();
            CreateMap<TransactionsHistorique, TransactionHistoriqueDto>().ReverseMap();

            //serveur
            CreateMap<Enregistrement, EnregistrementDto>().ReverseMap();
            CreateMap<Anomalie, AnomalieDto>().ReverseMap();

        }
    }
}


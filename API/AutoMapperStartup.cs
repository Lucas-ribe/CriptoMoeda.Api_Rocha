﻿using Adapter.MercadoBitcoinAdapter;
using AutoMapper;
using criptomoeda.api.Dtos;
using Domain.Models;
using Dtos;

namespace baseMap
{
    public static class AutoMapperStartup
    {
        public static void AddAutoMapperCustomizado(this IServiceCollection servicos)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullDestinationValues = true;
                mc.AllowNullCollections = true;
                mc.AddProfile(new MappingProfile());
                mc.AddProfile(new MercadoBitcoinMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            servicos.AddSingleton(mapper);
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<NegociacoesDoDia, NegociacoesDoDiaGetResult>();
                CreateMap<NegociacoesDoDia, HistoricoDeNegociacoes>();
                CreateMap<HistoricoDeNegociacoes, HistoricoDTO>();
                CreateMap<NegociacoesDoDia, RegistroDeNegociacoes>();
                CreateMap<RegistroDeNegociacoes, HistoricoDTO>();
            }
        }
    }
}

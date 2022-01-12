using ArtistsMVCDemo.Dtos;
using ArtistsMVCDemo.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtistsMVCDemo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Album, AlbumDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title));

            Mapper.CreateMap<AlbumDto, Album>()
                .ForMember(dest=> dest.Title, opt=> opt.MapFrom(src => src.Name));

            Mapper.CreateMap<Artist, ArtistDto>();
            Mapper.CreateMap<ArtistDto, Artist>();

            Mapper.CreateMap<Message, MessageDto>();
            Mapper.CreateMap<MessageDto, Message>();
        }
    }
}
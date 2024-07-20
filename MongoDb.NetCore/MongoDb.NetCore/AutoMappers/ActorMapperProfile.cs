using AutoMapper;
using MongoDb.NetCore.Dtos;
using MongoDb.NetCore.Models;
using MongoDB.Bson;

namespace MongoDb.NetCore.AutoMappers
{
    public class ActorMapperProfile : Profile
    {
        public ActorMapperProfile()
        {
            CreateMap<ActorDto, Actor>()
                .ForMember(destination => destination.Id, options => options.MapFrom(source => (BsonValue)source.Id)).ReverseMap();
        }
    }
}

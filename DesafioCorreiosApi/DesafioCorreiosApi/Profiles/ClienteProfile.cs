using AutoMapper;
using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;

namespace DesafioCorreiosApi.Profiles;

public class ClienteProfile: Profile
{

    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>().ReverseMap();
        CreateMap<ReadClienteDto, Cliente>()
            .ForMember(dest => dest.Endereco, 
                opt => opt.MapFrom(src => src.Endereco))
            .ReverseMap();
        CreateMap<ReadEnderecoDto, Endereco>().ReverseMap();
    }
}

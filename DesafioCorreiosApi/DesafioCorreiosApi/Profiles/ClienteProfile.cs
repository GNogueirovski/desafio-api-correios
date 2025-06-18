using AutoMapper;
using DesafioCorreiosApi.Data.Dtos;
using DesafioCorreiosApi.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DesafioCorreiosApi.Profiles;

public class ClienteProfile: Profile
{

    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>().ReverseMap();
        CreateMap<ReadClienteDto, Cliente>().ReverseMap();
    }
}

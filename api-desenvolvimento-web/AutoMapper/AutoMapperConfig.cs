using api_desenvolvimento_web.DTO;
using api_desenvolvimento_web.Models;
using AutoMapper;

namespace api_desenvolvimento_web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        { 
            CreateMap<CriarUsuarioModel, CriarUsuarioDTO>().ReverseMap();
            CreateMap<LoginModel, LoginDTO>().ReverseMap();
            CreateMap<ResetarSenhaModel, ResetarSenhaDTO>().ReverseMap();
        }
    }
}
